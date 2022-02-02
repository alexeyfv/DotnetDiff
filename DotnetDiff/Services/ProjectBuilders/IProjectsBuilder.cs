﻿using DotnetDiff.Models;

namespace DotnetDiff.Services.ProjectBuilders
{
    public interface IProjectsBuilder
    {
        void Build(IEnumerable<Project> projects);
    }
}