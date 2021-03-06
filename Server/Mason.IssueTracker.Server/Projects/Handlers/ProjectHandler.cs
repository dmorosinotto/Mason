﻿using Mason.IssueTracker.Server.Domain.Projects;
using Mason.IssueTracker.Server.Projects.Resources;
using Mason.Net;
using OpenRasta.Web;
using System;


namespace Mason.IssueTracker.Server.Projects.Handlers
{
  public class ProjectHandler : BaseHandler
  {
    #region Dependencies

    public IProjectRepository ProjectRepository { get; set; }

    #endregion


    public object Get(int id)
    {
      return ExecuteInUnitOfWork(() =>
      {
        Project p = ProjectRepository.Get(id);
        return new ProjectResource
        {
          Project = p
        };
      });
    }


    public object Post(int id, UpdateProjectArgs args)
    {
      return ExecuteInUnitOfWork(() =>
      {
        Project p = ProjectRepository.Get(id);
        p.Update(args.Code, args.Title, args.Description);
        return new ProjectResource
        {
          Project = p
        };
      });
    }


    public object Delete(int id)
    {
      return ExecuteInUnitOfWork(() =>
      {
        Project p = ProjectRepository.Get(id);
        ProjectRepository.Delete(p);
        return new OperationResult.NoContent();
      });
    }
  }
}
