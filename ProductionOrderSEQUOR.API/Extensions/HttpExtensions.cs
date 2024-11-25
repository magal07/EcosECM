﻿using ProductionOrderSEQUOR.API.Models;
using System.Text.Json;

namespace ProductionOrderSEQUOR.API.Extensions
{
    public static class HttpExtensions
    {
        public static void AddPaginationHeader(this HttpResponse response, PaginationHeader header)
        {
            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            response.Headers.Add("Pagination", JsonSerializer.Serialize(header, jsonOptions));
            response.Headers.Add("Acess-Control-Expose-Headers", "Pagination");
        }
    }
}