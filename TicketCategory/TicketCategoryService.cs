using AutoMapper;

namespace HelpDesk.TicketCategory;

public class TicketCategoryService : ITicketCategoryService
{
    private readonly ITicketCategoryRepository _repository;
    private readonly IMapper _mapper;

    public TicketCategoryService(ITicketCategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<TicketCategoryDTO>> GetAllAsync()
    {
        var categories = await _repository.GetAllAsync();
        return _mapper.Map<List<TicketCategoryDTO>>(categories);
    }

    public async Task<TicketCategoryDTO> GetByIdAsync(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        return _mapper.Map<TicketCategoryDTO>(category);
    }

    public async Task<TicketCategoryDTO> CreateAsync(TicketCategoryCreateUpdateDTO categoryDto)
    {
        var category = _mapper.Map<TicketCategoryModel>(categoryDto);
        var newCategory = await _repository.CreateAsync(category);
        return _mapper.Map<TicketCategoryDTO>(newCategory);
    }

    public async Task<TicketCategoryDTO> UpdateAsync(int id, TicketCategoryCreateUpdateDTO categoryDto)
    {
        var category = await _repository.GetByIdAsync(id);
        _mapper.Map(categoryDto, category);
        var updatedCategory = await _repository.UpdateAsync(category);
        return _mapper.Map<TicketCategoryDTO>(updatedCategory);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }
}