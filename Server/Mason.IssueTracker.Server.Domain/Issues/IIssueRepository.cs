﻿using System.Collections.Generic;


namespace Mason.IssueTracker.Server.Domain.Issues
{
  public class IssueSearchArgs
  {
    public long? Id { get; set; }
    public string TextQuery { get; set; }
  }


  public interface IIssueRepository
  {
    Issue Get(long id);
    List<Issue> FindIssues(IssueSearchArgs args);
    void Add(Issue i);
  }
}