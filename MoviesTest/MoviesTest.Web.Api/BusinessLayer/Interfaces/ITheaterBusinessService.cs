﻿using MoviesTest.Sdk.Interfaces;
using MoviesTest.Web.Api.BusinessLayer.Models;

namespace MoviesTest.Web.Api.BusinessLayer.Interfaces;

public interface ITheaterBusinessService: IBusinessRepository<TheaterModel, long>
{
}