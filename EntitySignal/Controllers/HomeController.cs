﻿using EntitySignal.Data;
using EntitySignal.Hubs;
using EntitySignal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EntitySignal.Controllers
{

  public class SubscribePost
  {
    public string ConnectionId { get; set; }
  }

  [ResponseCache(NoStore = true, Duration = 0)]
  public class HomeController : Controller
  {
    private ApplicationDbContext _db;
    public IHubContext<EntitySignalHub, IDataClient> _dataHubContext { get; }

    public HomeController(
      ApplicationDbContext context,
      IHubContext<EntitySignalHub, IDataClient> dataHubContext
      )
    {
      _db = context;
      _dataHubContext = dataHubContext;
    }

    public async Task<IActionResult> Index()
    {
      var messages = await _db.Messages
         .ToListAsync();

      return View();
    }

    [HttpGet("/Stats")]
    public IActionResult Stats()
    {
      return View();
    }

    [HttpGet("quick-start")]
    public IActionResult GetStarted()
    {
      return View();
    }

    [HttpGet("documentation")]
    public IActionResult Docs()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
