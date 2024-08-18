﻿using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;

namespace PetFamily.Domain.Models.Pets;

public sealed class PetPhoto : Shared.Entity<PetPhotoId>
{
    private PetPhoto(PetPhotoId id, string path, bool isMain)
        : base(id)
    {
        Path = path;
        IsMain = isMain;
    }

    public string Path { get; private set; }

    public bool IsMain { get; private set; }

    public static Result<PetPhoto, Error> Create(PetPhotoId id, string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return Errors.General.ValueIsInvalid("Path");

        return new PetPhoto(id, path, false);
    }

    public static Result<PetPhoto, Error> CreateIsMain(PetPhotoId id, string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return Errors.General.ValueIsInvalid("Path");

        return new PetPhoto(id, path, true);
    }
}