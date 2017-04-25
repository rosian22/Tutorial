using DataLayer.Implementation;
using Models;
using SitulClasei.BusinessLogic.TypeManagement;
using SitulClasei.BusinessLogic.Workflow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Core
{
    public class StudentGroupCore
    {
        private StudentGroupCore()
        {
        }
        public static async Task<Group> AddAsync(Guid groupId, Guid studentId)
        {
            using (var unitOfWork = RepoUnitOfWork.NewTracking<StudentGroupCore>())
            {
                var groupRepository = unitOfWork.Repository<DataLayer.GroupRepository>();
                var studentRepository = unitOfWork.Repository<StudentRepository>();

                var group = await groupRepository.GetAsync(groupId, new[]
                {
                    nameof(Group.Students)
                }).ConfigureAwait(false);
                if (group == null)
                {
                    unitOfWork.RollbackTransaction();
                    return null;
                }

                if (group.Students.Any(stud => stud.Id == groupId))
                {
                    return group.CopyTo<Group>();
                }

                var student = await studentRepository.GetAsync(studentId).ConfigureAwait(false);
                if (student == null)
                {
                    unitOfWork.RollbackTransaction();
                    return null;
                }
                group.Students.Add(student);

                var updatedGroup = await groupRepository.UpdateAsync(group, true).ConfigureAwait(false);
                if (updatedGroup == null)
                {
                    unitOfWork.RollbackTransaction();
                    return null;
                }
                unitOfWork.CommitTransaction();
                return updatedGroup.CopyTo<Group>();
            }
        }
        public static async Task<IList<StudentGroupAssigmentsModel>> GetAsync(Guid groupId)
        {
            using (var groupsRepository = RepoUnitOfWork.CreateRepository<DataLayer.GroupRepository>())
            {
                var group = await groupsRepository.GetAsync(groupId, new[]
                {
                    nameof(Group.Students),
                    $"{nameof(Group.Students)}.{nameof(Student.Age)}"
                }).ConfigureAwait(false);

                return group?.Students == null ? null : Process(group);
            }
        }



        private static List<StudentGroupAssigmentsModel> Process(DataLayer.Group group)
        {
            if (group == null)
            {
                return new List<StudentGroupAssigmentsModel>();
            }

            var stdgr = group.Students.Select(student => new StudentGroupAssigmentsModel
            {
                StudentId = student.Id
            }).ToList();
            return stdgr;

        }

        private static List<StudentGroupAssigmentsModel> ProcessStudent(DataLayer.Student student)
        {
            if (student == null)
            {
                return new List<StudentGroupAssigmentsModel>();
            }
            var std = student.Groups.Select(group => new StudentGroupAssigmentsModel
            {
                GroupId = group.Id
            }).ToList();
            return std;
        }
    }
}
