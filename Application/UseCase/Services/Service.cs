using Application.Interfaces;
using AutoMapper;
using Application.DTO.Error;
using Microsoft.EntityFrameworkCore;
using Application.DTO.Pagination;

namespace Application.UseCase.Services
{
    public abstract class Service<Request, Response, T> : IService<Request, Response> where Request : class where Response : class where T : class
    {
        protected readonly IRepository<T> _repository;
        protected readonly IMapper _mapper;
        public Parameters parameters;

        public Service(IRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            parameters = new();
        }
        public async Task<Response> Create(Request request)
        {
            try
            {
                T entity = _mapper.Map<T>(request);
                entity = await _repository.Insert(entity);
                return _mapper.Map<Response>(entity);
            }
            catch (Exception e)
            {
                if (e is HTTPError)
                {
                    throw e;
                }
                if (e is DbUpdateException)
                {
                    throw new ConflictException("There is a record with the same identifier.");
                }
                throw new InternalServerErrorException(e.Message);
            }
        }

        public async Task DeleteById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new BadRequestException("The ID must be greater than zero.");
                }
                var entity = await _repository.RecoveryById(id);
                if (entity != null)
                {
                    await _repository.Remove(entity);
                    await _repository.SaveChanges();
                }
                else
                {
                    throw new NotFoundException("The record with ID " + id + " was not found.");
                }
            }
            catch (Exception e)
            {
                if (e is HTTPError)
                {
                    throw e;
                }
                throw new InternalServerErrorException(e.Message);
            }
        }

        public async Task<Paged<Response>> GetAll(int pagedNumber, int pagedSize)
        {
            try
            {
                if (pagedNumber>=0 && pagedSize>=0)
                {
                    parameters.PageSize = pagedSize;
                    parameters.PageNumber = pagedNumber;
                } else
                {
                    throw new BadRequestException("Ingrese valores válidos para pagedNumber y pagedSize.");
                }

                Paged<T> list = await _repository.RecoveryAll(parameters);
                List<Response> listAux = new();
                list.Data.ForEach(e => listAux.Add(_mapper.Map<Response>(e)));

                return new Paged<Response>(listAux, list.MetaData.TotalCount, parameters.PageNumber, parameters.PageSize);
            }
            catch (Exception e)
            {
                if (e is HTTPError)
                {
                    throw e;
                }
                throw new InternalServerErrorException(e.Message);
            }
        }

        public async Task<Response> GetById(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new BadRequestException("The ID must be greater than zero.");
                }

                var entity = await _repository.RecoveryById(id);
                if (entity == null)
                {
                    throw new NotFoundException("The record with ID " + id + " was not found.");
                }
                return _mapper.Map<Response>(entity);
            }
            catch (Exception e)
            {
                if (e is HTTPError)
                {
                    throw e;
                }
                throw new InternalServerErrorException(e.Message);
            }
        }

        public virtual Task<Response> Update(int id, Request request)
        {
            throw new NotImplementedException();
        }
    }
}
