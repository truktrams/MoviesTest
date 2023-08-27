﻿using MoviesTest.Sdk.Interfaces;
using MoviesTest.Web.Api.DataLayer.Projections;

namespace MoviesTest.Web.Api.DataLayer.Interfaces;

public interface IUserDataService: IDataRepository<UserProjection, long>
{
}