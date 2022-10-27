#!/usr/bin/env python3
import os

import aws_cdk as cdk

from iyarles_stack.i_yarles_stack import IYarlesStack


app = cdk.App()
IYarlesStack(app, "IYarlesStack")

app.synth()
