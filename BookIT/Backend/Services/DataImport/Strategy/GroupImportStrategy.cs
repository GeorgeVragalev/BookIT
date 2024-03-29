﻿using AutoMapper;
using Backend.Entities.UniversityEntities;
using Backend.Helpers;
using Backend.Models;
using Backend.Services.University.DepartmentService;
using Backend.Services.University.GroupService;
using CsvHelper;

namespace Backend.Services.DataImport.Strategy;

public class GroupImportStrategy : IStrategy
{
    private readonly IGroupService _groupService;

    public GroupImportStrategy(IGroupService groupService)
    {
        _groupService = groupService;
    }

    public async Task<bool> Import(IMapper mapper, CsvReader csvReader)
    {
        try
        {
            var groupModels = csvReader.GetRecords<GroupModel>().ToList();

            foreach (var model in groupModels)
            {
                var group = mapper.Map<Group>(model);
                await _groupService.Save(group);
            }

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}