#!/usr/bin/env sh

current_tag=`git name-rev --name-only --tags HEAD`

if [ "${current_tag}" = "undefined" ]; then
  echo "no current tag; exiting"
  exit 0
fi

package_version=${current_tag:1:5}

dotnet pack Float.xAPI/Float.xAPI.fsproj /p:Configuration=Release /p:PackageVersion="${package_version}"
dotnet nuget push Float.xAPI/bin/Release/*.nupkg -k $NUGET_KEY -s $NUGET_SOURCE
