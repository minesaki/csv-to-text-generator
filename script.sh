#!/bin/sh

# Run setup.sh first if .NET Core 3.0+/.NET Script/.NET T4 not installed
# .NET Core 3.0+/.NET Script/.NET T4がインストールされていない場合、setup.shを実行してください

# Generate text generation code from T4 template file
# T4テンプレートからテキスト生成用コードを生成
t4 -c MyTemplate -o MyTemplate.generated.cs MyTemplate.tt

# Generate text and print to console
# テキストを生成してコンソールに表示
#dotnet script CodeGen.csx -- mydata.csv

# Generate text and save to file. (also printed in console)
# テキストを生成してファイルに出力（コンソールにも表示されます）
dotnet script CodeGen.csx -- mydata.csv output
