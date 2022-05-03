﻿using EldoradoApi.Models.Sizes;

namespace EldoradoApi.Services;

public interface ISizeService
{
    Task CreateSize(SizeCreate model);
    Task<IEnumerable<SizeObject>> GetSizes();
    Task<SizeObject> GetSizeById(int id);
    Task<SizeObject> UpdateSize(int id, SizeUpdate model);
    Task<SizeObject> DeleteSize(int id);
}