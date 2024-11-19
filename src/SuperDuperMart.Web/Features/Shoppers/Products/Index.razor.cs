﻿using Microsoft.AspNetCore.Components;
using SuperDuperMart.Shared.Models;

namespace SuperDuperMart.Web.Features.Shoppers.Products
{
    public partial class Index
    {
        [Inject]
        public IConfiguration Configuration { get; set; } = default!;

        [Inject]
        public IHttpService HttpService { get; set; } = default!;

        private bool _loading = true;

        public ResultDto<ProductDto> Model { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            int pageNumber = Configuration.GetValue<int>("Pagination:Default:PageNumber");
            int pageSize = Configuration.GetValue<int>("Pagination:Default:PageSize");

            Model = new(pageNumber, pageSize);

            await GetProducts(Model.PageNumber, Model.PageSize);
        }

        private async Task GetProducts(int pageNumber, int pageSize)
        {
            string? url = $"{Endpoints.Products}?pageNumber={pageNumber}&pageSize={pageSize}";

            var result = await HttpService.GetAsync<ResultDto<ProductDto>>(url);
            if (result != null)
            {
                Model = result;
            }

            _loading = false;
        }

        private async Task HandleGetMoreProductsClick()
        {
        }
    }
}
