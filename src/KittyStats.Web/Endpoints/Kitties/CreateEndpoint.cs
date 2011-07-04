using System;
using FubuMVC.Core.Continuations;
using KittyStats.Domain;
using KittyStats.Web.Models;

namespace KittyStats.Web.Endpoints.Kitties
{
    public class CreateEndpoint
    {
        private readonly IRepository _repository;

        public CreateEndpoint(IRepository repository)
        {
            _repository = repository;
        }

        public Kitty Get(CreateKittyRequest request)
        {
            return new Kitty
                       {
                           BirthDate = DateTime.Now.AddDays(-14)
                       };
        }

        public FubuContinuation Post(Kitty input)
        {
            _repository.Insert(input);
            _repository.Save();
            return FubuContinuation.RedirectTo(new DashboardRequestModel());
        }
    }
}