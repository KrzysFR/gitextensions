        public Encoding FilesContentEncoding { get; private set; }

        public PatchProcessor(Encoding filesContentEncoding)
        {
            FilesContentEncoding = filesContentEncoding;
        }

        /// <summary>
        /// Diff part of patch is printed verbatim, everything else (header, warnings, ...) is printed in git encoding (Settings.SystemEncoding) 
        /// Since patch may contain diff for more than one file, it would be nice to obtaining encoding for each of file
        /// from .gitattributes, for now there is used one encoding, common for every file in repo (Settings.FilesEncoding)
        /// File path can be quoted see core.quotepath, it is unquoted by GitCommandHelpers.ReEncodeFileNameFromLossless
        /// </summary>
        /// <param name="textReader"></param>
        /// <returns></returns>
                    input = GitCommandHelpers.ReEncodeFileNameFromLossless(input);
                        if (patch.Type == Patch.PatchType.ChangeFileMode)
                        {
                            patch.AppendTextLine(input);
                        }
                        else if (!IsIndexLine(input))
                        input = GitCommandHelpers.ReEncodeFileNameFromLossless(input);
                        if (IsUnlistedBinaryFileDelete(input))
        private void ValidateInput(ref string input, Patch patch, bool gitPatch)
            else if (HasOldFileName(input))
                input = GitCommandHelpers.ReEncodeFileNameFromLossless(input);
            else if (IsNewFileMissing(input))
            else if (input.StartsWith("+++ ") && !IsNewFileMissing(input))
                input = GitCommandHelpers.ReEncodeFileNameFromLossless(input);
            else if (input.StartsWithAny(new string[] { " ", "-", "+", "@" }))
                input = GitCommandHelpers.ReEncodeStringFromLossless(input, FilesContentEncoding);
            else
                input = GitCommandHelpers.ReEncodeStringFromLossless(input, Settings.SystemEncoding);
            else if (input.StartsWith("old mode "))
                patch.Type = Patch.PatchType.ChangeFileMode;