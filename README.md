
##PaperPortSafeConverter

A C# Winforms wrapper to Nuance PaperPort's "cvmaxpdf_console.exe" (and "cvmaxpdf.exe") MAX to PDF conversion tool - hardened against the random and frequent file parsing crashes that are so frequent with these tools

### Background

I recently inherited a large PaperPort document archive in the (now-legacy) ".MAX" document format, and rapidly came to realize a couple of very irritating things:
* There are a number of free viewers available at different places on the web, but none of them are practical to use
* Of the many versions of PaperPort released over the years, none were hardened against the fragile-as-glass "MAX" format; a single broken MAX file kills the whole PaperPort process, regardless of version
* Even though the default file format for PaperPort changed from MAX to PDF at some point over the years/releases, the latest versions still suffer the same issues with MAX files
* Worse than processes crashing, these programs (all of them, as far as I can tell) DESTROY partially-broken files when attempting to open them. Once you try to open a file, whatever data might have been there is (inadvertently) deleted. For some reason all the viewers open the files in "Read+Write" mode and go haywire destroying data when there is an errro
* A "MAX to PDF" conversion program/wizard is included in the later versions of Paperport, but
    * The same data loss issues apply (failed conversion deleted data from original file)
    * A single failure causes the whole conversion job to fail, so this program is effectively useless on large partially-corrupted repositories
    * Besides failing, sometimes the conversion process simply hangs in an infinite loop
    * Some failures are silent, and result in a 0-byte PDF being generated even though success is reported

On the other hand, there is some good news:
* The "MAX to PDF" conversion wizard has a (single-file-at-a-time) commandline equivalent, "cvmaxpdf_console.exe"
* This commandline program accepts the same conversion options, including input language filter for automatic OCR during the PDF conversion
* The latest version of Paperport (14) is not too unpleasant to work with. When documents are converted, it's once again an OK system for eyeballing/managing large sets of scanned documents, now in a standard PDF format

### Conversion process

Due to this combination of circumstances, and my need to extract as much usable information as possible from this old MAX file archive, I wrote a small C# winforms front-end to the command-line conversion program, which:
* Iterates through the target folder (recursively)
* For each MAX file found:
** Copies it to a temp folder, in a mirror folder hierarchy
** Tries to run the conversion program in an error-handling "sandbox", so that a crash of the conversion does not affect the C# program
*** with OCR enabled, for French; you need to change the call to the command-line program slightly for other languages
** If the conversion is successful (and the resulting PDF not empty!), saves the converted file to a mirror "success" folder hierarchy (and deleted any leftovers from the rrror folders)
** Otherwise, grabs a copy of the original MAX file to save in the error folder hierarchy, so that any manual followup is actually working on the "raw" file, not the "corrupted-during-reading" version.

#### Result

The result of the process running is:
* A "failure" folder hierarchy, containing any MAX files that could not be converted
* A "converted" folder hierarchy, containing all the successfully-converted PDF files
* The original folder hierarchy, UNTOUCHED, in case you should later need to apply any other conversion process

### Copyright / License

This is a case of "Do what you want, just don't blame me for the result", so the MIT license applies:

Copyright (c) 2013 Tao Klerks

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.