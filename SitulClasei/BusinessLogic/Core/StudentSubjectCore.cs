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
    public class StudentSubjectCore
    {
        private StudentSubjectCore()
        {
        }
        public static async Task<Subject> AddAsync(Guid subjectId, Guid studentId)
        {
            using (var unitOfWork = RepoUnitOfWork.NewTracking<StudentSubjectCore>())
            {
                var subjectRepository = unitOfWork.Repository<DataLayer.SubjectRepository>();
                var studentRepository = unitOfWork.Repository<StudentRepository>();

                var subject = await subjectRepository.GetAsync(subjectId, new[]
                {
                    nameof(Subject.Students)
                }).ConfigureAwait(false);
                if (subject == null)
                {
                    unitOfWork.RollbackTransaction();
                    return null;
                }

                if (subject.Students.Any(stud => stud.Id == subjectId))
                {
                    return subject.CopyTo<Subject>();
                }

                var student = await studentRepository.GetAsync(studentId).ConfigureAwait(false);
                if (student == null)
                {
                    unitOfWork.RollbackTransaction();
                    return null;
                }
                subject.Students.Add(student);

                var updatedSubject = await subjectRepository.UpdateAsync(subject, true).ConfigureAwait(false);
                if (updatedSubject == null)
                {
                    unitOfWork.RollbackTransaction();
                    return null;
                }
                unitOfWork.CommitTransaction();
                return updatedSubject.CopyTo<Subject>();
            }
        }
        public static async Task<IList<StudentSubjectAssigmentsModel>> GetAsync(Guid subjectId)
        {
            using (var subjectsRepository = RepoUnitOfWork.CreateRepository<DataLayer.SubjectRepository>())
            {
                var subject = await subjectsRepository.GetAsync(subjectId, new[]
                {
                    nameof(Subject.Students),
                    $"{nameof(Subject.Students)}.{nameof(Student.Age)}"
                }).ConfigureAwait(false);

                return subject?.Students == null ? null : Process(subject);
            }
        }



        private static List<StudentSubjectAssigmentsModel> Process(DataLayer.Subject subject)
        {
            if (subject == null)
            {
                return new List<StudentSubjectAssigmentsModel>();
            }

            var stdgr = subject.Students.Select(student => new StudentSubjectAssigmentsModel
            {
                StudentID = student.Id
            }).ToList();
            return stdgr;

        }

        private static List<StudentSubjectAssigmentsModel> ProcessStudent(DataLayer.Student student)
        {
            if (student == null)
            {
                return new List<StudentSubjectAssigmentsModel>();
            }
            var std = student.Groups.Select(subject => new StudentSubjectAssigmentsModel
            {
                SubjectID = subject.Id
            }).ToList();
            return std;
        }
    }
}
