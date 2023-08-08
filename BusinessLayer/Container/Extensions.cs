using BusinessLayer.Abstract;
using BusinessLayer.Abstract.UnitOfWork;
using BusinessLayer.Abstract.Utilities;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.UnitOfWork;
using BusinessLayer.Concrete.Utilities;
using DataAccessLayer.Concrete.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccessLayer.Concrete.UnitOfWork;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Container
{
    public static class ServiceExtensions
    {
        public static void ContainerDependencies(this IServiceCollection Services)
        {
            Services.AddScoped<ICommentDal, EfCommentDal>();

            Services.AddScoped<ICommentService, CommentManager>();
            Services.AddScoped<IDestinationDal, EfDestinationDal>();

            Services.AddScoped<IDestinationService, DestinationManager>();
            Services.AddScoped<IAppUserDal, EfAppUserDal>();

            Services.AddScoped<IAppUserService, AppUserManager>();
            Services.AddScoped<IReservationDal, EfReservationDal>();

            Services.AddScoped<IReservationService, ReservationManager>();
            Services.AddScoped<IGuideDal, EfGuideDal>();

            Services.AddScoped<IGuideService, GuideManager>();
            Services.AddScoped<IExcelService, ExcelManager>();


            Services.AddScoped<IContactUsDal, EfCountactUsDal>();
            Services.AddScoped<IContactUsService, ContactUsManager>();

            Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
            Services.AddScoped<IAnnouncementService, AnnouncementManager>();

            Services.AddScoped<IAccountDal, EfAccountDal>();
            Services.AddScoped<IAccountService, AccountManager>();

            Services.AddScoped<IGuideDal, EfGuideDal>();
            Services.AddScoped<IGuideService, GuideManager>();

            Services.AddScoped<IUnitOfWorkDal, UnitOfWorkDal>();
        }
    }
}
