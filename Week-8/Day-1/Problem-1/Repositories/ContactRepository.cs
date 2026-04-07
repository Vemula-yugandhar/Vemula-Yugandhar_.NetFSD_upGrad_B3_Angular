using Dapper;
using Dapper_Service_and_Repository_ContactIInformation.Models;
using Microsoft.Data.SqlClient;

namespace Dapper_Service_and_Repository_ContactIInformation.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly string _connStr;

        public ContactRepository(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection")!;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connStr);
        }

        public List<ContactInfo> GetAllContacts()
        {
            string sql = @"
                SELECT c.ContactId, c.FirstName, c.LastName, c.EmailId, c.MobileNo, c.Designation,
                       c.CompanyId, c.DepartmentId,
                       comp.CompanyName, dept.DepartmentName
                FROM ContactInfo c
                INNER JOIN Company comp ON c.CompanyId = comp.CompanyId
                LEFT JOIN Department dept ON c.DepartmentId = dept.DepartmentId
                ORDER BY c.ContactId ";

            using var db = GetConnection();
            return db.Query<ContactInfo>(sql).ToList();
        }

        public ContactInfo? GetContactById(int id)
        {
            string sql = @"
                SELECT c.ContactId, c.FirstName, c.LastName, c.EmailId, c.MobileNo, c.Designation,
                       c.CompanyId, c.DepartmentId,
                       comp.CompanyName, dept.DepartmentName
                FROM ContactInfo c
                INNER JOIN Company comp ON c.CompanyId = comp.CompanyId
                LEFT JOIN Department dept ON c.DepartmentId = dept.DepartmentId
                WHERE c.ContactId = @Id";

            using var db = GetConnection();
            return db.QueryFirstOrDefault<ContactInfo>(sql, new { Id = id });
        }

        public void AddContact(ContactInfo contact)
        {
            string sql = @"
                INSERT INTO ContactInfo
                (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
                VALUES
                (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";

            using var db = GetConnection();
            db.Execute(sql, contact);
        }

        public void UpdateContact(ContactInfo contact)
        {
            string sql = @"
                UPDATE ContactInfo
                SET FirstName = @FirstName,
                    LastName = @LastName,
                    EmailId = @EmailId,
                    MobileNo = @MobileNo,
                    Designation = @Designation,
                    CompanyId = @CompanyId,
                    DepartmentId = @DepartmentId
                WHERE ContactId = @ContactId";

            using var db = GetConnection();
            db.Execute(sql, contact);
        }

        public void DeleteContact(int id)
        {
            string sql = "DELETE FROM ContactInfo WHERE ContactId = @Id";

            using var db = GetConnection();
            db.Execute(sql);
        }

        public List<Company> GetCompanies()
        {
            string sql = "SELECT CompanyId, CompanyName FROM Company";

            using var db = GetConnection();
            return db.Query<Company>(sql).ToList();
        }

        public List<Department> GetDepartments()
        {
            string sql = "SELECT DepartmentId, DepartmentName FROM Department";

            using var db = GetConnection();
            return db.Query<Department>(sql).ToList();
        }

        
    }
}