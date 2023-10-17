using Microsoft.EntityFrameworkCore;
using TKC_MDS.Models;

namespace TKC_MDS.Data
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder builder)
        {

			#region saveOrder_roles
			var saveOrder_roles = new List<SaveOrderRoles> {
                new SaveOrderRoles{Name="ViewOrder", Description="View"},
				new SaveOrderRoles{Name="CreateOrder",Description="Create"},
				new SaveOrderRoles{Name="EditOrder", Description = "Edit"},
				new SaveOrderRoles{Name="DeleteOrder",Description="Delete"},
			};
            builder.Entity<SaveOrderRoles>().HasData(saveOrder_roles);
			#endregion
			#region adjOrder_roles
			var adjOrder_roles = new List<AdjustOrderRoles> {
				new AdjustOrderRoles{Name="ViewAdjustOrder", Description = "View"},
				new AdjustOrderRoles{Name="CreateAdjustOrder",Description="Create"},
				new AdjustOrderRoles{Name="EditAdjustOrder", Description = "Edit"},
				new AdjustOrderRoles{Name="DeleteAdjustOrder", Description="Delete"},
			};
			builder.Entity<AdjustOrderRoles>().HasData(adjOrder_roles);
			#endregion
			#region dataType_roles
			var dataType_roles = new List<DataTypeRoles> {
				new DataTypeRoles{Name="ViewDataType", Description = "View"},
				new DataTypeRoles{Name="CreateDataType",Description="Create"},
				new DataTypeRoles{Name="EditDataType", Description = "Edit"},
				new DataTypeRoles{Name="DeleteDataType", Description="Delete"},
			};
			builder.Entity<DataTypeRoles>().HasData(dataType_roles);
			#endregion
			#region report_roles
			var report_roles = new List<ReportRoles> {
				new ReportRoles{Name="ViewReport",Description = "View"},
				new ReportRoles{Name="CreateReport",Description="Create"},
				new ReportRoles{Name="EditReport",Description = "Edit"},
				new ReportRoles{Name="DeleteReport",Description="Delete"},
			};
			builder.Entity<ReportRoles>().HasData(report_roles);
			#endregion
			#region manageUser_roles
			var manageUser_roles = new List<ManageUserRoles> {
				new ManageUserRoles{Name="ViewUser", Description = "View"},
				new ManageUserRoles{Name="CreateUser",Description="Create"},
				new ManageUserRoles{Name="EditUser",Description = "Edit"},
				new ManageUserRoles{Name="DeleteUser",Description="Delete"},
			};
			builder.Entity<ManageUserRoles>().HasData(manageUser_roles);
			#endregion


		}
	}
}
