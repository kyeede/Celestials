#!/bin/bash

dotrun() {
    # 1. Local scope for safety
    local OPTIND opt project config log_prefix timestamp
    project=""
    config="Debug"
    timestamp=$(date +'%Y-%m-%d %H:%M:%S')
    log_prefix="[DOTRUN][$timestamp]"

    # 2. Parse arguments
    while getopts "p:r" opt; do
        case "$opt" in
            p) project="$OPTARG" ;;
            r) config="Release" ;;
            *) echo "$log_prefix ERROR: Usage: dotrun -p <project> [-r]" >&2; return 1 ;;
        esac
    done
    shift $((OPTIND - 1))

    # 3. Environment Validation (The "Enterprise" check)
    if ! command -v dotnet >/dev/null 2>&1; then
        echo "$log_prefix FATAL: .NET SDK is not installed or not in PATH." >&2
        return 127
    fi

    # 4. Input Validation
    if [[ -z "$project" ]]; then
        echo "$log_prefix ERROR: Project path is required. Use -p <path_to_csproj>." >&2
        return 1
    fi

    if [[ ! -f "$project" ]]; then
        echo "$log_prefix ERROR: Project file not found: $project" >&2
        return 1
    fi

    # 5. Execution Pipeline
    echo "$log_prefix INFO: Starting pipeline for [$project] in ($config) mode..."

    # We use a subshell or a block to capture the whole sequence
    {
        dotnet clean "$project" && \
        dotnet restore "$project" && \
        dotnet build "$project" --configuration "$config" --no-restore && \
        echo "$log_prefix SUCCESS: Build complete. Launching application..." && \
        dotnet run --project "$project" --configuration "$config" --no-build
    } || {
        local exit_code=$?
        echo "$log_prefix FATAL: Pipeline failed with exit code $exit_code" >&2
        return $exit_code
    }
}

dotrun "$@"
