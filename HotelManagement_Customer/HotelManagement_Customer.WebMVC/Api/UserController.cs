using HotelManagement_Customer.Model.Model;
using HotelManagement_Customer.Service;
using HotelManagement_Customer.Service.Services;
using HotelManagement_Customer.WebMVC.Infractructure.Core;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelManagement_Customer.WebMVC.Api
{
    // reduce dependence for easy maintainence, testing,...
    [RoutePrefix("api/user")]
    public class UserController : ApiControllerBase
    {
        IUserServices _userService;
        // now don't run, because the dependence has not create
        public UserController(IErrorServices errorServices, IUserServices userService)
            : base(errorServices)
        {
            this._userService = userService;
        }

        [Route("get")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid == true)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listUser = _userService.GetAllAccounts();

                    response = request.CreateResponse(HttpStatusCode.OK, listUser);
                }
                return response;
            });
        }

        [Route("adduser")]
        public HttpResponseMessage Post(HttpRequestMessage request, UserAccount userAccount)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid == true)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _userService.Add(userAccount);
                    _userService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.Created);
                }
                return response;
            });
        }

        //updating....
        public HttpResponseMessage Put(HttpRequestMessage request, UserAccount userAccount)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid == true)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _userService.Add(userAccount);
                    _userService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.Created);
                }
                return response;
            });
        }

        //updating...
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid == true)
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    _userService.Delete(id);
                    _userService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.Created);
                }
                return response;
            });
        }
    }
}
