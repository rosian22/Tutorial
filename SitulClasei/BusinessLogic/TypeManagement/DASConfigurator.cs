using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Models;

namespace BusinessLogic.TypeManagementS { 
    public static class DasConfigurator
    {
        internal static void ConfigureAspNetUsers(IMapperConfiguration config)
        {
            config.CreateMap<AspNetUser, DataLayer.AspNetUser>();

            config.CreateMap<DataLayer.AspNetUser, AspNetUser>();
        }
        internal static void ConfigureStudents(IMapperConfiguration config)
        {
            config.CreateMap<Student, DataLayer.Student>();

            config.CreateMap<DataLayer.Student, Student>();
        }
        internal static void ConfigureSubjects(IMapperConfiguration config)
        {
            config.CreateMap<Subject, DataLayer.Subject>();

            config.CreateMap<DataLayer.Subject, Subject>();
        }
        internal static void ConfigureGroups(IMapperConfiguration config)
        {
            config.CreateMap<Group, DataLayer.Group>();

            config.CreateMap<DataLayer.Group, Group>();
        }

        #region Item configuration extension methods

        private static void Configure<T>(this IEnumerable<T> items, Action<T> applyConfiguration)
        {
            if (items == null)
            {
                return;
            }

            foreach (var item in items)
            {
                applyConfiguration(item);
            }
        }

        private static void Configure<T>(this T item, Action<T> applyConfiguration)
        {
            if (item == null)
            {
                return;
            }

            applyConfiguration(item);
        }

        #endregion
    }
}