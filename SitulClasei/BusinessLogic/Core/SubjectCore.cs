using Models;
using SitulClasei.BusinessLogic.Core.Base;
using DataLayer;
using SitulClasei.BusinessLogic.Workflow;
using BusinessLogic.Model;
using System.Threading.Tasks;
using BusinessLogic.Constants;
using SitulClasei.BusinessLogic.Workflow.Interfaces;
using System;
using System.Linq.Expressions;
using SitulClasei.DataLayer.Extensions.Linq;
using System.Linq;
using BusinessLogic.Model.Pagination;
using SitulClasei.BusinessLogic.TypeManagement;
using System.Collections.Generic;
using Common.Enums;
namespace BusinessLogic.Core
{
    public class SubjectCore : BaseSinglePkCore<SubjectRepository, Models.Subject, DataLayer.Subject>
    {
        public static async Task<FilterEntityContainerWrapper<Models.Subject>> GetFiltered(int pageNumber = 0, StudentSubjectFilterModel model = null, IList<string> navigationProperties = null)
        {
            using (var subjectRepository = RepoUnitOfWork.CreateRepository<SubjectRepository>())
            {
                if (model == null)
                {
                    model = StudentSubjectFilterModel.Default();
                }

                var entityContainerWraper = new FilterEntityContainerWrapper<Models.Subject>();
                var entityContainers = new List<EntityContainer<Models.Subject>>();

                var subjectQuery = subjectRepository.GetAllQuery(navigationProperties);

                var offeredPaginationData = ExtractTotalPagesAsync(subjectQuery, model);


                if (pageNumber > offeredPaginationData.TotalPages)
                {
                    pageNumber = 0;
                }


                var offeredShiftsModel = await GetOrderShiftsByFilter(null, pageNumber, offeredPaginationData.TotalPages, model, navigationProperties).ConfigureAwait(false);

                entityContainers.Add(offeredShiftsModel);

                entityContainerWraper.EntityContainers = entityContainers;
                entityContainerWraper.TotalItems = offeredPaginationData.TotalEntryCount;

                return entityContainerWraper;
            }
        }

        private static async Task<EntityContainer<Models.Subject>> GetOrderShiftsByFilter(SubjectRepository subjectsRepository, int currentPageNumber, int numberOfPages, StudentSubjectFilterModel model, IList<string> navigationProperties = null)
        {
            if (subjectsRepository == null)
            {
                subjectsRepository = RepoUnitOfWork.CreateRepository<SubjectRepository>();
            }

            using (var subjectQuery = GetFilterQuery(subjectsRepository, model, navigationProperties))
            {
                if (!subjectQuery.IsValid)
                {
                    return new EntityContainer<Models.Subject>
                    {
                        CurrentPage = 0,
                        TotalPages = 0,
                        Data = new List<Models.Subject>()
                    };
                }

                var orderedQuery = subjectQuery.OrderBy(subject => subject.SubjectName).Paginate(currentPageNumber, PaginationConstants.REGISTRATION_PER_PAGE);
                var subjectList = await orderedQuery.ExecuteAsync().ConfigureAwait(false);

                if (subjectList == null)
                {
                    subjectList = new List<Models.Subject>();
                }

                return new EntityContainer<Models.Subject>
                {
                    CurrentPage = currentPageNumber,
                    TotalPages = numberOfPages,
                    Data = subjectList.CopyTo<Models.Subject>().ToList()
                };
            }
        }

        public static IConfigurableQuery<DataLayer.Subject, Models.Subject> GetFilterQuery(SubjectRepository subjectsRepository, StudentSubjectFilterModel model, IList<string> navigationProperties = null)
        {
            var filterExpression = GetFilterExpression(model);
            var subjectsQuery = subjectsRepository.GetListQuery(filterExpression, navigationProperties);

            return new ConfigurableQuery<DataLayer.Subject, Models.Subject>(subjectsRepository.Context, subjectsQuery);
        }

        public static Expression<Func<DataLayer.Subject, bool>> GetFilterExpression(StudentSubjectFilterModel model)
        {
            Expression<Func<DataLayer.Subject, bool>> expression = (e => e != null);

            expression = expression.AndAlso(subject =>
                ((model.SubjectId == Guid.Empty) || (subject.Id == model.SubjectId)));

            return expression;
        }


        private static PaginationData ExtractTotalPagesAsync(IQueryable<DataLayer.Subject> subjects, StudentSubjectFilterModel model)
        {
            var filterExpression = GetFilterExpression(model);
            var count = subjects.Count(filterExpression);

            double numberOfPages = ((double)count) / PaginationConstants.REGISTRATION_PER_PAGE;
            var totalPages = (int)Math.Ceiling(numberOfPages);


            return new PaginationData
            {
                TotalEntryCount = count,
                TotalPages = totalPages
            };
        }

        public static async Task<IList<Models.Subject>> GetAllWithEntityStatusAsync(EntityStatus status, IList<string> navigationProperties = null)
        {
            using (var subjectRepository = RepoUnitOfWork.CreateRepository<SubjectRepository>())
            {
                var subjects = await subjectRepository.GetListAsync(subject => subject.EntityStatus == (int)status,
                    navigationProperties).ConfigureAwait(false);

                return subjects.CopyTo<Models.Subject>();
            }
        }



        //endregion
    }

}

