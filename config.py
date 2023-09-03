import os
GLOB_FILTER = "**/*.hmm"

def build(system):
    curdir = os.path.basename(os.getcwd())
    system.AddSourceDirectory("./", GLOB_FILTER)

    if curdir != "Globals":
        system.AddSourceDirectory("../Globals/", GLOB_FILTER)