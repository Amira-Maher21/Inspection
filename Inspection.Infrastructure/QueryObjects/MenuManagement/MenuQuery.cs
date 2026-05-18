using Inspection.Application.Contracts.Dto.MenuManagement;
using NDS.Shared.Application.DataQuery;
using NDS.Shared.Application.Multitenant;
using NDS.Shared.Infrastructure.DataContext;
using NDS.Shared.Kernel.BaseReturnTypes;
using NDS.Shared.Kernel.Exceptions;

namespace Inspection.Infrastructure.QueryObjects.MenuManagement
{
    internal class MenuQuery : QueryObjectBase<MenuDto>
    {
        public MenuQuery(ISqlQueryBuilder queryBuilder, DapperDbContext dapper, ITenantResolver tenantResolver, IExceptionManager exceptionManager, string? fiscalYear = null) : base(queryBuilder, dapper, tenantResolver, exceptionManager, fiscalYear)
        {
        }

        public override async Task<ReturnBase<IEnumerable<MenuDto>>> Query(SqlQueryOptions queryOptions)
        {

            throw new NotImplementedException();
        }

        public override async Task<ReturnBase<IEnumerable<MenuDto>>> Query(SqlQueryOptions queryOptions, string ProgramID)
        {
            throw new NotImplementedException();
        }

        //    public override async Task<ReturnBase<IEnumerable<MenuDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        //    {
        //        try
        //        {
        //            string query = @"SELECT m.Menu_ID, m.Parent_ID, m.Menu_Name , m.WebRoute, m.Program_ID, m.Icon
        //FROM   Screen_permission AS sp INNER JOIN
        //            Screen_Code AS sc ON sp.Screen_ID = sc.Screen_ID INNER JOIN
        //            User_Code_dGroup AS ucd ON sp.User_group_ID = ucd.User_group_ID AND sp.Tenant_ID = ucd.Tenant_ID RIGHT OUTER JOIN
        //            Menu AS m ON sc.Menu_ID = m.Menu_ID
        //WHERE  (ucd.User_ID = @UserID OR ucd.User_ID IS NULL) AND m.Program_ID = @ProgramID";
        //            Dictionary<string, object> parameters;
        //            if (functionParameters.Length > 0)
        //            {
        //                parameters = new()
        //                    {
        //                        { "@UserID", _tenantResolver.GetCommonUserData().UserName },
        //                        {"@ProgramID", functionParameters[0].ToString()}
        //                    };
        //            }
        //            else
        //            {
        //                parameters = new()
        //                    {
        //                        { "@UserID", _tenantResolver.GetCommonUserData().UserName },
        //                        {"@ProgramID", ""}
        //                    };
        //            }
        //            ReturnBase<IEnumerable<MenuDto>> queryResult = await _dapper.QueryList<MenuDto>(query, parameters.ToDictionary());

        //            if (queryResult.Succeeded)
        //                return queryResult;
        //            return ReturnBase<IEnumerable<MenuDto>>.Fail(queryResult.Errors);
        //        }
        //        catch (Exception ex)
        //        {
        //            return ReturnBase<IEnumerable<MenuDto>>.Fail(ex, this._exceptionManager);
        //        }
        //    }

        public override async Task<ReturnBase<IEnumerable<MenuDto>>> Query(SqlQueryOptions queryOptions, object[] functionParameters)
        {
            try
            {
                string query = @"
                    SELECT m.Menu_ID, m.Parent_ID, m.Menu_Name, m.WebRoute, m.Program_ID, m.Icon
                    FROM   Sec.Screen_permission AS sp 
                    INNER JOIN Syst.Screen_Code AS sc ON sp.Screen_ID = sc.Screen_ID 
                    INNER JOIN Sec.User_Code_dGroup AS ucd ON sp.User_group_ID = ucd.User_group_ID AND sp.Tenant_ID = ucd.Tenant_ID 
                    RIGHT OUTER JOIN Syst.Menu AS m ON sc.Menu_ID = m.Menu_ID
                    WHERE (ucd.Id = @UserID OR ucd.Id IS NULL)";

                //Dictionary<string, object> parameters = new()
                //{
                //    { "@UserID", Convert.ToInt64(_tenantResolver.GetCommonUserData().UserName) }
                //};


                Dictionary<string, object> parameters = new()
                {
                    { "@UserID", 4L }
                };

                ReturnBase<IEnumerable<MenuDto>> queryResult = await _dapper.QueryList<MenuDto>(query, parameters.ToDictionary());

                if (queryResult.Succeeded)
                    return queryResult;

                return ReturnBase<IEnumerable<MenuDto>>.Fail(queryResult.Errors);
            }
            catch (Exception ex)
            {
                return ReturnBase<IEnumerable<MenuDto>>.Fail(ex, this._exceptionManager);
            }
        }


    }
}
