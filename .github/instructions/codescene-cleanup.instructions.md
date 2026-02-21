---
description: Analyze a file with CodeScene and systematically fix all code health issues
applyTo: **/*
---

# CodeScene Cleanup Skill

This skill analyzes a file using CodeScene's code health review and systematically addresses each identified issue using fresh subagent context windows.

## Usage

When user requests "codescene-cleanup" for a file, follow this workflow:

## Step 1: Analyze the File

Run CodeScene analysis on the target file:
- Call `code_health_review` with the file path
- Parse the results to extract all problems
- Note the current Code Health score

## Step 2: Create TODO List

For each problem identified in the CodeScene review:
- Create a TODO item with:
  - Function name
  - Problem category (e.g., "Complex Method", "Bumpy Road Ahead")
  - Severity details (e.g., cyclomatic complexity, number of bumps)
  - Line range

Use `manage_todo_list` to track all issues.

## Step 3: Solve Each Problem in Sequence

For each TODO item:

1. **Mark as in-progress** using `manage_todo_list`

2. **Spawn a subagent** using `runSubagent` with:
   ```
   Description: "Fix [category] in [function]"
   
   Prompt: "You are refactoring code to improve Code Health.
   
   File: [file_path]
   Function: [function_name] (lines [start]-[end])
   Issue: [category] - [details]
   
   Your task:
   1. Read the function and understand its current implementation
   2. Identify the specific code health issue
   3. Refactor the code to resolve the issue while preserving behavior
   4. Verify the fix by running code_health_review on the modified file
   5. Ensure Code Health score improves or at minimum stays the same
   6. Run all tests to ensure no regression
   
   Return a summary of:
   - What you changed
   - Before/after Code Health scores
   - Test results"
   ```

3. **Mark as completed** after subagent reports success

4. **Move to next TODO**

## Step 4: Final Verification

After all issues are addressed:
- Run `code_health_review` on the complete file
- Verify Code Health score has improved
- Run `pre_commit_code_health_safeguard` to ensure no regressions
- Report final score vs. initial score

## Key Principles

- **One issue at a time**: Each subagent gets a fresh context focused on one specific problem
- **Test-first safety**: Always run tests after each fix
- **Incremental progress**: Track completion of each issue
- **Code Health validation**: Verify improvement after each change
- **Aim for 10.0**: Don't stop until Code Health reaches optimal level

## Example Invocation

User says: "codescene-cleanup Game.cs"

You would:
1. Run code_health_review on Game.cs
2. Create TODOs for each issue found
3. Spawn subagents to fix each issue sequentially
4. Report final Code Health improvement
