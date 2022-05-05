﻿using DepartmentLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthCareApp.Data
{
    public class DepartmentService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DepartmentService(ApplicationDbContext applicationDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _applicationDbContext = applicationDbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        // async method to get list of departments
        public async Task<List<Department>> GetDepartmentsAsync()
        {
            UserService userService = new UserService(_httpContextAccessor);
            List<Department> departmentList = new List<Department>();

            /* Raw query with joins, filters and ordering */
            var query =
                (
                    from department in _applicationDbContext.Set<Department>()
                    where department.InsertedBy == userService.UserId()
                    orderby department.CreatedAt descending
                    select new { department }
                ).AsNoTracking();

            foreach (var i in query)
            {
                departmentList.Add(SetDepartmentDetails(i.department));
            }

            return await Task.FromResult(departmentList);
        }

        /*
         * method to get department by ID
         */
        public Department GetDepartmentById(Guid guid)
        {
            try
            {
                UserService userService = new(_httpContextAccessor);

                /* Raw query with joins, filters and ordering */
                var query =
                    (
                        from employee in _applicationDbContext.Set<Department>()
                        where employee.Id == guid
                        select new { employee }
                    ).AsNoTracking().FirstOrDefault();

                return SetDepartmentDetails(query.employee);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Department>> SearchAsync(string searchTerm)
        {
            UserService userService = new(_httpContextAccessor);
            List<Department> departmentList = new();

            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return departmentList;
            }

            var query =
                (
                    from department in _applicationDbContext.Set<Department>()
                    where department.InsertedBy == userService.UserId()
                    && EF.Functions.Like(department.Name, $"%{searchTerm}%")
                    orderby department.CreatedAt descending
                    select new { department }
                ).AsNoTracking();

            foreach (var i in query)
            {
                departmentList.Add(SetDepartmentDetails(i.department));
            }

            return await Task.FromResult(departmentList);
        }

        /*
         * async method to add new department
         */
        public async Task<Department> AddDepartmentAsync(Department department)
        {

            UserService userService = new UserService(_httpContextAccessor);

            department.IsActive = true;
            department.CreatedAt = department.UpdatedAt = DateTime.UtcNow;
            // Get current logged user ID
            department.InsertedBy = userService.UserId();

            try
            {
                _applicationDbContext.Department.Add(department);
                await _applicationDbContext.SaveChangesAsync();

                /*
                 * Because we are using AsNoTracking() in our query, 
                 * we need to detach all state entities with EntityState.Detached
                 * to avoid exception when adding a record or updating the same record more than once
                 */
                _applicationDbContext.Entry(department).State = EntityState.Detached;
            }
            catch (Exception)
            {
                throw;
            }

            return department;
        }

        /*
         * async method to update department
         */
        public async Task<bool> UpdateDepartmentAsync(Department department)
        {
            department.UpdatedAt = DateTime.UtcNow;

            try
            {
                _applicationDbContext.Department.Update(department);
                await _applicationDbContext.SaveChangesAsync();

                /*
                 * Because we are using AsNoTracking() in our query, 
                 * we need to detach all state entities with EntityState.Detached
                 * to avoid exception when adding a record or updating the same record more than once
                 */
                _applicationDbContext.Entry(department).State = EntityState.Detached;
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        private static Department SetDepartmentDetails(Department department)
        {
            Department departmentDetails = department;

            return departmentDetails;
        }
    }
}
