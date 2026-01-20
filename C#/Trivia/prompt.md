You will be cleaning up some legacy code.
Use the following command to build the code and get feedback on the code quality:

# Visual marker

In every message start with visual marker ⛑️

# Necessary commands

## Run analysis and run tests

```[powershell]
.\scripts\analyze-and-run-tests.ps1
```

# Cleanup process

* Make a TODO list of all errors in the build output.
* Fix the errors one by one:
  * Clean the code
  * **IMMEDIATELY** run analsysis and tests to verify that the tests still pass and get analysis feedback
* When all errors (and potential subsequently introduced errors) have been fixed, consider the task done.

**CRITICAL**: Never skip the test and analysis verification steps between fixes. Each fix must be validated immediately before proceeding to the next one.