#!/usr/bin/env sh

set -eu

commit_link_prefix="https://github.com/gowithfloat/xapi/commit/"
current_tag=`git name-rev --name-only --tags HEAD`

if [ "${current_tag}" = "undefined" ]; then
  echo "no current tag; no release"
  exit 0
fi

echo "tag is ${current_tag}"

previous_tag=`git describe --abbrev=0 --tags "${current_tag}"^`

if [ "${previous_tag}" = "undefined" ]; then
  echo "no previous tag; no release"
  exit 1
fi

echo "prev tag is ${previous_tag}"

IFS=$'\n'
change_list=( `git log --pretty=oneline "${previous_tag}"..."${current_tag}"` )

for change in ${change_list[@]}; do
  commit_hash=${change%%" "*}
  short_hash=${commit_hash:0:7}
  commit_message=${change#*" "}
  echo "[\`${short_hash}\`](${commit_link_prefix}${commit_hash}) ${commit_message}" >> release_notes.md
done

sh pack.sh
