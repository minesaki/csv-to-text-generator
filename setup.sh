#!/bin/sh

DOTNET_VERSION=3.1.100

# install .NET Core SDK
# (since code is written in C# 8, .NET 3.0+ required to run) 
dotnet --list-sdks | grep $DOTNET_VERSION >/dev/null 2>&1
if [ $? -ne 0 ]; then
  echo "Installing .NET Core SDK..."
  curl -L --ssl https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --version $DOTNET_VERSION
  echo "Installing .NET Core SDK: done"
else
  echo ".NET Core runtime has already installed."
fi

# how to uninstall .NET Core
## [Mac] https://docs.microsoft.com/ja-jp/dotnet/core/versions/remove-runtime-sdk-versions?tabs=macos
## [Linux] https://docs.microsoft.com/ja-jp/dotnet/core/versions/remove-runtime-sdk-versions?tabs=linux

# install .NET Script (to run C# program as script)
dotnet tool install -g dotnet-script

# install .NET T4 (Text Template Transformation Toolkit)
dotnet tool install -g dotnet-t4
