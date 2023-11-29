#!/bin/sh
echo -ne '\033c\033]0;FlappySimplr\a'
base_path="$(dirname "$(realpath "$0")")"
"$base_path/FlappySimplr.x86_64" "$@"
