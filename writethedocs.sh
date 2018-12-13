#!/usr/bin/env sh

set +euxr

input_path="Float.xAPI/bin/Debug/netstandard2.0/Float.xAPI.XML"
output_path="docs/index.md"

if [ ! -f "${input_path}" ]; then
  echo "Build the xAPI project first to generate XML file."
  exit 1
fi

if [ ! -f "Float.VSDocGen/bin/Debug/Float.VSDocGen.exe" ]; then
  echo "Building VSDocGen executable..."
  msbuild Float.VSDocGen/Float.VSDocGen.fsproj
fi

echo "Generating documentation..."
mono Float.VSDocGen/bin/Debug/Float.VSDocGen.exe \
  "${input_path}" \
  "${output_path}"

echo "Done."
