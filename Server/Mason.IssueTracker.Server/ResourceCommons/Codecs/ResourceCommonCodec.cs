﻿using Mason.IssueTracker.Server.Codecs;
using Mason.IssueTracker.Server.JsonSchemas.Resources;
using Mason.IssueTracker.Server.Projects.Resources;
using Mason.IssueTracker.Server.ResourceCommons.Resources;
using Mason.IssueTracker.Server.Utility;
using Mason.Net;
using OpenRasta.Web;
using System;


namespace Mason.IssueTracker.Server.ResourceCommons.Codecs
{
  public class ResourceCommonCodec : IssueTrackerMasonCodec<ResourceCommonResource>
  {
    protected override Net.Resource ConvertToIssueTracker(ResourceCommonResource resource)
    {
      Resource cm = resource.Value;
      return cm;
    }
  }
}
