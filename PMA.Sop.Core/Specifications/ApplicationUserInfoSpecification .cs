﻿using Ardalis.Specification;
using PMA.Sop.Domain.User.Entities;

namespace PMA.Sop.ApplicationServices.Specifications
{
    public sealed class ApplicationUserInfoSpecification : Specification<UserInfo>
    {
        public ApplicationUserInfoSpecification(int applicationUserId)
        {
            Query.Where(x => x.ApplicationUserId == applicationUserId);
        }
    }
}