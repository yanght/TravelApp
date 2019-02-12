using System.Collections.Generic;
using TravelApp.Roles.Dto;

namespace TravelApp.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}