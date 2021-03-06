﻿using Mason.IssueTracker.Server.Issues.Resources;
using Mason.IssueTracker.Server.Codecs;
using Mason.IssueTracker.Server.Domain.Issues;
using Mason.Net;
using OpenRasta.Web;
using System;
using System.Collections.Generic;


namespace Mason.IssueTracker.Server.Issues.Codecs
{
  public class IssueQueryCodec : IssueTrackerMasonCodec<IssueQueryResource>
  {
    protected override Resource ConvertToIssueTracker(IssueQueryResource resource)
    {
      dynamic result = new Resource();

      if (!CommunicationContext.PreferMinimalResponse())
      {
        result.SetMeta(MasonProperties.MetaProperties.Title, "Query result");
        result.SetMeta(MasonProperties.MetaProperties.Description, "This is the result of a query for issues. Follow issues 'self' link to get more information about individual issues.");
      }

      result.AddLinkTemplate(CommunicationContext.BuildIssueQueryTemplate());

      result.Issues = new List<SubResource>();

      foreach (Issue i in resource.Issues)
      {
        dynamic item = new SubResource();
        item.ID = i.Id.ToString();
        item.Title = i.Title;

        Uri itemSelfUri = typeof(IssueResource).CreateUri(new { id = i.Id });
        Link itemSelfLink = CommunicationContext.NewLink("self", itemSelfUri);
        item.AddLink(itemSelfLink);

        result.Issues.Add(item);
      }

      Link selfLink = CommunicationContext.NewLink("self", resource.SelfUri);
      result.AddLink(selfLink);

      return result;
    }
  }
}
