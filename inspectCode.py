# Author: Mathias Dam Hedelund
# Contributors: 
import os
import xml.etree.ElementTree as ET

# Constant filenames
XMLFILENAME = "inspectCodeOutput.xml"
MDFILENAME = "inspectCodeOutput.md"
IGNOREDFILENAME = "ignoredIssues.csv"

# Issues set to be ignored
ignoredIssues = open(IGNOREDFILENAME).read()
ignoredIssues = str(ignoredIssues).split(',')

# Run ReSharper
os.system("inspectcode.exe .\MGP2.sln -o=\"" + XMLFILENAME + "\"")

# Get issues from XML output
tree = ET.parse(XMLFILENAME)
root = tree.getroot()
issues = root.find('Issues')
issueArray = issues.find('Project').findall('Issue')

# Open .md file and initialize variables
outputFile = open(MDFILENAME, 'w')
issueCounter = 0
outString = ""

# Loop through issues and write them
for child in issueArray:
    # Ignore issue if included in ignoredIssues
    typeId = child.get('TypeId')
    if (typeId in ignoredIssues):
        pass

    fileName = child.get('File')
    line = child.get('Line')
    if (line is None):
        line = "1"
    message = child.get('Message')

    # Format issue nicely
    outString += "**" + fileName + "**\n"
    outString += "*Issue type: " + typeId + "*\n"
    outString += "*Line: " + line + "*\n"
    outString += "Message: " + message + "\n"
    outString += "\n"

    issueCounter += 1

# Write to file and close
outputFile.write("Issues: " + str(issueCounter) + "\n\n")
outputFile.write(outString)
outputFile.close()

# Clean up XML file
os.remove(XMLFILENAME)

# Report success
print("Inspection report was converted to markdown and written to " + os.getcwd() + "\\" + MDFILENAME)
