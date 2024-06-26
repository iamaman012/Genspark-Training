﻿using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface ISolutionFeedbackBL
    {
        Task<SolutionFeedback> GiveFeedback(SolutionFeedback feedback);
        Task<ICollection<SolutionFeedback>> ViewFeedback(Employee employee);
    }
}
