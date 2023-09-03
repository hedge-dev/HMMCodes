#!/usr/bin/python3

import os
import sys
import glob

def mkdir(path):
    if not os.path.isdir(path):
        os.mkdir(path)

class BuildSystem:
    def __init__(self) -> None:
        self.sources = []

    def AddSourceFile(self, path) -> None:
        if os.path.isfile(path):
            self.sources.append(os.path.abspath(path))

    def AddSourceDirectory(self, path, filter) -> None:
        for file in glob.glob(path + filter, recursive=True):
            self.AddSourceFile(file)

        pass

    def Build(self) -> str:
        contents = ""
        for file in self.sources:
            with open(file, "r", encoding='utf8') as f:
                contents += f.read()
                contents += "\n"
            pass
        
        return contents
    
    def BuildToFile(self, path) -> None:
        with open(path, "w", encoding='utf8') as f:
            f.write(self.Build())

        pass

def BuildFolder(dir, outPath = None) -> None:
    if not os.path.isdir(dir):
        return
    
    if outPath is None:
        outPath = "build/" + str.replace(os.path.basename(dir), " ", "") + ".hmm"

    system = BuildSystem()
    curdir = os.getcwd()
    os.chdir(dir)
    sys.path.insert(0, os.getcwd())
    try:
        import config as cfg
        cfg.build(system) # type: ignore
        sys.path.pop(0)

    except ImportError:
        sys.path.pop(0)
        pass

    os.chdir(curdir)
    system.BuildToFile(outPath)
    pass

def BuildAll(dir) -> None:
    if not os.path.isdir(dir):
        return
    
    for file in glob.glob(dir + "/*", recursive=False):
        if os.path.isdir(file):
            BuildFolder(file)

    globalCodeFile = "!Global.hmm"

    if not os.path.isfile("build/" + globalCodeFile):
        return
    
    globalData = ""
    for file in glob.glob("build/*.hmm"):
        if os.path.basename(file) == globalCodeFile:
            with open(file, "r", encoding='utf8') as f:
                globalData += f.read()
                globalData += "\n"
            pass
        else:
            with open(file, "a", encoding='utf8') as f:
                f.write(globalData)
            pass
            


mkdir("build")
BuildAll("Source")