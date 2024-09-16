#!/bin/bash

if [ $(basename "$PWD") != "MondialMunch" ]; then
    echo "You have to run this in the MondialMunch directory."
    kill -INT $$
fi

echo "Building migration"
migration_name=$(openssl rand -hex 6)
dotnet ef migrations add "$migration_name"
dotnet ef database update

echo "Cleaning up old migrations"
find Migrations -type f ! \( -name "*$migration_name*.cs" -o -name "MondialMunchContextModelSnapshot.cs" \) -exec rm {} \;
