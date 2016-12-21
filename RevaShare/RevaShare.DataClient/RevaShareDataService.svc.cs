using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RevaShare.DataAccess;
using RevaShare.DataAccess.Data;
using RevaShare.DataClient.Mappers;
using RevaShare.DataClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RevaShare.DataClient
{
  public partial class RevaShareDataService : IRevaShareDataService
  {
    private RevaShareDBEntities _context;

    public RevaShareDataService(RevaShareDBEntities context)
    {
      _context = context;
    }

    public RevaShareDataService()
    {
      _context = new RevaShareDBEntities();
    }

    RevaShareData data = new RevaShareData();
  }
}
