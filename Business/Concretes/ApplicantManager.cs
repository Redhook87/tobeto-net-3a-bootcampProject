using Business.Abstracts;
using Business.Requests.Applicants;
using Business.Responses.Applicants;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class ApplicantManager : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepo;
        public ApplicantManager(IApplicantRepository applicantRepository)
        {
            _applicantRepo = applicantRepository;
        }

        public async Task<List<GetAllApplicantResponse>> GetAll()
        {
            List<GetAllApplicantResponse> instructors = new List<GetAllApplicantResponse>();
            foreach (var applicant in await _applicantRepo.GetAll())
            {
                GetAllApplicantResponse response = new();
                response.UserId = applicant.Id;
                response.About = applicant.About;
                instructors.Add(response);
            }
            return instructors;
        }

        public async Task<GetByIdApplicantResponse> GetById(int id)
        {
            GetByIdApplicantResponse response = new();
            Applicant applicant = await _applicantRepo.Get(x => x.Id == id);
            response.UserId = applicant.Id;
            response.About = applicant.About;
            return response;
        }

        public async Task<CreateApplicantResponse> AddAsync(CreateApplicantRequest request)
        {
            Applicant applicant = new();
            applicant.Id = request.UserId;
            applicant.About = request.About;
            await _applicantRepo.Add(applicant);

            CreateApplicantResponse response = new();
            response.UserId = applicant.Id;
            response.About = applicant.About;
            return response;
        }

        public async Task<DeleteApplicantResponse> DeleteAsync(DeleteApplicantRequest request)
        {
            Applicant applicant = new();
            applicant.Id = request.UserId;
            applicant.About = request.About;
            await _applicantRepo.Delete(applicant);

            DeleteApplicantResponse response = new();
            response.UserId = request.UserId;
            response.About = request.About;
            return response;
        }

        public async Task<UpdateApplicantResponse> UpdateAsync(UpdateApplicantRequest request)
        {
            Applicant applicant = await _applicantRepo.Get(x => x.Id == request.UserId);
            applicant.Id = request.UserId;
            applicant.About = request.About;
            await _applicantRepo.Update(applicant);

            UpdateApplicantResponse response = new();
            response.UserId = applicant.Id;
            response.About = applicant.About;
            return response;
        }
    }
}
