﻿using ProjectManagement.Application.Repositories.Queries.Base;
using ProjectManagement.Domain.Entities;

namespace ProjectManagement.Application.Repositories.Queries
{
    public interface IProjectQueryRepository:IQueryRepository<Project>
    {
    }
}
