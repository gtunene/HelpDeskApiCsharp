using AutoMapper;

namespace HelpDesk.TicketCategory;

public class TicketCategoryService
{
    private readonly TicketCategoryRepository _repository;
    private readonly IMapper _mapper;

    public TicketCategoryService(TicketCategoryRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<List<TicketCategoryDTO>> GetAllAsync()
    {
        var categories = await _repository.GetAllAsync();
        return _mapper.Map<List<TicketCategoryDTO>>(categories);
    }

    public async Task<TicketCategoryDTO?> GetByIdAsync(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        return category == null ? null : _mapper.Map<TicketCategoryDTO>(category);
    }

    public async Task<TicketCategoryDTO> CreateAsync(TicketCategoryCreateUpdateDTO categoryDto)
    {
        var category = _mapper.Map<TicketCategoryModel>(categoryDto);
        await _repository.AddAsync(category);
        return _mapper.Map<TicketCategoryDTO>(category);
    }

    public async Task<TicketCategoryDTO?> UpdateAsync(int id, TicketCategoryCreateUpdateDTO categoryDto)
    {
        var category = await _repository.GetByIdAsync(id);
        if (category == null)
        {
            return null;
        }
        _mapper.Map(categoryDto, category);
        await _repository.UpdateAsync(category);
        return _mapper.Map<TicketCategoryDTO>(category);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var category = await _repository.GetByIdAsync(id);
        if (category == null)
        {
            return false;
        }
        await _repository.DeleteAsync(category);
        return true;
    }
}