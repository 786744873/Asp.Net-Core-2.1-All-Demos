﻿using System.Collections.Generic;
using MPACore.PhoneBook.Roles.Dto;

namespace MPACore.PhoneBook.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleListDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}
