using AutoMapper;
using Deals.Data;
using Deals.Dto.Society;
using Deals.Dto.User;
using Deals.Interface;
using Deals.Models;
using Microsoft.EntityFrameworkCore;

namespace Deals.Repository
{
    public class SocietyRepository : ISociety
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public SocietyRepository(DataContext dataContext , IMapper mapper)

        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<SocietyDto>> AddSociety(Society requestSocietyDto)
        {
            var response = new ServiceResponse<SocietyDto>();
            if( await SocietyExits(requestSocietyDto.Name))
            {
                response.Success = false;
                response.Message = "Society already exists.";
                return response;

            }

            response.Message = "Society Added Successfully";
            _dataContext.Add(requestSocietyDto);
            await _dataContext.SaveChangesAsync();
            return response;
        }
        public async Task<bool> SocietyExits(string username)
        {
            if (await _dataContext.Societies.AnyAsync(u => u.Name.ToLower() == username.ToLower()))
            {
                return true;

            }
            return false;
        }

        public async Task<ServiceResponse<List<Society>>> GetAllSocieties()
        {
            var response = new ServiceResponse<List<Society>>();

            var societies = await _dataContext.Societies.ToListAsync();
            if (societies is null)
            {
                response.Success = false;
                response.Message = "No Society Found";
            }

            response.Data = societies.Select(c => _mapper.Map<Society>(c)).ToList();
            return response;
        }


        public async Task<ServiceResponse<SocietyDto>> GetSocietyByID(int SocietyID)
        {

            var response = new ServiceResponse<SocietyDto>();
            var society =  await _dataContext.Societies.Where(s => s.SocietyId == SocietyID).FirstOrDefaultAsync();
            if (society is null)
            {
                response.Success = false;
                response.Message = "  society not found";
            }
           
            else
            {
                response.Data = _mapper.Map<SocietyDto>(society);
            }
            return response;
        }

        public async Task<ServiceResponse<SocietyDto>> UpdateSocietyStatus(int SocietyID, bool Status)
        {
            var response = new ServiceResponse<SocietyDto>();
            var society = await _dataContext.Societies.Where(u => u.SocietyId == SocietyID ).FirstOrDefaultAsync();
            if (society is null)
            {
                response.Success = false;
                response.Message = "Society of Id " + SocietyID + " not found";
            }
            else
            {

                society.Status = Status;
                await _dataContext.SaveChangesAsync();
                response.Data = _mapper.Map<SocietyDto>(society);
                response.Message = " status updated successfully";
            }

            return response;
        }

        public async Task<ServiceResponse<SocietyDto>> UpdateSociety(UpdateSocietyDto SocietyRequest)
        {

            var response = new ServiceResponse<SocietyDto>();
            var society = await _dataContext.Societies.Where(s => s.SocietyId == SocietyRequest.SocietyId).FirstOrDefaultAsync();
            if (society is null)
            {
                response.Success = false;
                response.Message = "Society of Id " + SocietyRequest.SocietyId + " not found";
            }
           
            else
            {
                society.Name = SocietyRequest.Name;
                society.City = SocietyRequest.City;
                society.Status = SocietyRequest.Status;


                await _dataContext.SaveChangesAsync();
                response.Data = _mapper.Map<SocietyDto>(society);
                response.Message = "Society updated successfully";
            }

            return response;
        }
    }
}
