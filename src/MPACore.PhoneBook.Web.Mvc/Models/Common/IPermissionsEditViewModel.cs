using System.Collections.Generic;
using MPACore.PhoneBook.Roles.Dto;

namespace MPACore.PhoneBook.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}