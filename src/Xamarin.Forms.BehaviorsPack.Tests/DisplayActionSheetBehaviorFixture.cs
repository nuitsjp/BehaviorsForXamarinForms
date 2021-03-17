﻿using System;
using System.Linq;
using System.Windows.Input;
using Moq;
using Xamarin.Forms.Internals;
using Xunit;

namespace Xamarin.Forms.BehaviorsPack.Tests
{
    public class DisplayActionSheetBehaviorFixture
    {
        [Fact]
        public void WhenSelectedCancelOnEventRaised()
        {
            var commandExecutorMock = new Mock<ICommandExecutor>();

            var cancelCommand = new Mock<ICommand>().Object;
            var cancelCommandParameter = new object();
            var cancelEventArgsConverter = new Mock<IValueConverter>().Object;
            var cancelEventArgsConverterParameter = new object();
            var cancelEventArgsPropertyPath = "cancelEventArgsPropertyPath";

            var destructionCommand = new Mock<ICommand>().Object;
            var destructionCommandParameter = new object();
            var destructionEventArgsConverter = new Mock<IValueConverter>().Object;
            var destructionEventArgsConverterParameter = new object();
            var destructionEventArgsPropertyPath = "destructionEventArgsPropertyPath";

            var behavior = new DisplayActionSheetBehavior()
            {
                CommandExecutor = commandExecutorMock.Object,
                EventName = "TestEvent",
                Title = "WhenCancelOnEventRaised",
                Cancel = "Cancel",
                CancelCommand = cancelCommand,
                CancelCommandParameter = cancelCommandParameter,
                CancelEventArgsConverter = cancelEventArgsConverter,
                CancelEventArgsConverterParameter = cancelEventArgsConverterParameter,
                CancelEventArgsPropertyPath = cancelEventArgsPropertyPath,
                Destruction = "Destruction",
                DestructionCommand = destructionCommand,
                DestructionCommandParameter = destructionCommandParameter,
                DestructionEventArgsConverter = destructionEventArgsConverter,
                DestructionEventArgsConverterParameter = destructionEventArgsConverterParameter,
                DestructionEventArgsPropertyPath = destructionEventArgsPropertyPath,
            };

            var actionSheetButtonMockA = new Mock<IActionSheetButton>();
            actionSheetButtonMockA.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockA");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockA.Object);

            var actionSheetButtonMockB = new Mock<IActionSheetButton>();
            actionSheetButtonMockB.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockB");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockB.Object);

            var page = new PageMock();
            page.Behaviors.Add(behavior);
            MessagingCenter.Subscribe<Page, ActionSheetArguments>(this, Page.ActionSheetSignalName, (page1, arguments) =>
            {
                if (arguments.Title == "WhenCancelOnEventRaised")
                {
                    Assert.Equal("Cancel", arguments.Cancel);
                    Assert.Equal("Destruction", arguments.Destruction);
                    Assert.Equal(2, arguments.Buttons.Count());
                    Assert.Equal("actionSheetButtonMockA", arguments.Buttons.ToArray()[0]);
                    Assert.Equal("actionSheetButtonMockB", arguments.Buttons.ToArray()[1]);
                    arguments.SetResult(arguments.Cancel);
                }
            });

            page.RiseTestEvent(this, EventArgs.Empty);

            commandExecutorMock.Verify(
                commandExecutor => commandExecutor.Execute(
                    cancelCommand,
                    cancelCommandParameter,
                    EventArgs.Empty,
                    cancelEventArgsConverter,
                    cancelEventArgsConverterParameter,
                    cancelEventArgsPropertyPath),
                Times.Once);

        }

        [Fact]
        public void WhenSelectedDestructionOnEventRaised()
        {
            var commandExecutorMock = new Mock<ICommandExecutor>();

            var cancelCommand = new Mock<ICommand>().Object;
            var cancelCommandParameter = new object();
            var cancelEventArgsConverter = new Mock<IValueConverter>().Object;
            var cancelEventArgsConverterParameter = new object();
            var cancelEventArgsPropertyPath = "cancelEventArgsPropertyPath";

            var destructionCommand = new Mock<ICommand>().Object;
            var destructionCommandParameter = new object();
            var destructionEventArgsConverter = new Mock<IValueConverter>().Object;
            var destructionEventArgsConverterParameter = new object();
            var destructionEventArgsPropertyPath = "destructionEventArgsPropertyPath";

            var behavior = new DisplayActionSheetBehavior()
            {
                CommandExecutor = commandExecutorMock.Object,
                EventName = "TestEvent",
                Title = "WhenSelectedDestructionOnEventRaised",
                Cancel = "Cancel",
                CancelCommand = cancelCommand,
                CancelCommandParameter = cancelCommandParameter,
                CancelEventArgsConverter = cancelEventArgsConverter,
                CancelEventArgsConverterParameter = cancelEventArgsConverterParameter,
                CancelEventArgsPropertyPath = cancelEventArgsPropertyPath,
                Destruction = "Destruction",
                DestructionCommand = destructionCommand,
                DestructionCommandParameter = destructionCommandParameter,
                DestructionEventArgsConverter = destructionEventArgsConverter,
                DestructionEventArgsConverterParameter = destructionEventArgsConverterParameter,
                DestructionEventArgsPropertyPath = destructionEventArgsPropertyPath,
            };

            var actionSheetButtonMockA = new Mock<IActionSheetButton>();
            actionSheetButtonMockA.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockA");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockA.Object);

            var actionSheetButtonMockB = new Mock<IActionSheetButton>();
            actionSheetButtonMockB.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockB");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockB.Object);

            var page = new PageMock();
            page.Behaviors.Add(behavior);
            MessagingCenter.Subscribe<Page, ActionSheetArguments>(this, Page.ActionSheetSignalName, (page1, arguments) =>
            {
                if (arguments.Title == "WhenSelectedDestructionOnEventRaised")
                {
                    Assert.Equal("Cancel", arguments.Cancel);
                    Assert.Equal("Destruction", arguments.Destruction);
                    Assert.Equal(2, arguments.Buttons.Count());
                    Assert.Equal("actionSheetButtonMockA", arguments.Buttons.ToArray()[0]);
                    Assert.Equal("actionSheetButtonMockB", arguments.Buttons.ToArray()[1]);
                    arguments.SetResult(arguments.Destruction);
                }
            });

            page.RiseTestEvent(this, EventArgs.Empty);

            commandExecutorMock.Verify(
                commandExecutor => commandExecutor.Execute(
                    destructionCommand,
                    destructionCommandParameter,
                    EventArgs.Empty,
                    destructionEventArgsConverter,
                    destructionEventArgsConverterParameter,
                    destructionEventArgsPropertyPath),
                Times.Once);

        }

        [Fact]
        public void WhenSelectedActionSheetButtonOnEventRaised()
        {
            var commandExecutorMock = new Mock<ICommandExecutor>();

            var cancelCommand = new Mock<ICommand>().Object;
            var cancelCommandParameter = new object();
            var cancelEventArgsConverter = new Mock<IValueConverter>().Object;
            var cancelEventArgsConverterParameter = new object();
            var cancelEventArgsPropertyPath = "cancelEventArgsPropertyPath";

            var destructionCommand = new Mock<ICommand>().Object;
            var destructionCommandParameter = new object();
            var destructionEventArgsConverter = new Mock<IValueConverter>().Object;
            var destructionEventArgsConverterParameter = new object();
            var destructionEventArgsPropertyPath = "destructionEventArgsPropertyPath";

            var behavior = new DisplayActionSheetBehavior()
            {
                CommandExecutor = commandExecutorMock.Object,
                EventName = "TestEvent",
                Title = "WhenSelectedActionSheetButtonOnEventRaised",
                Cancel = "Cancel",
                CancelCommand = cancelCommand,
                CancelCommandParameter = cancelCommandParameter,
                CancelEventArgsConverter = cancelEventArgsConverter,
                CancelEventArgsConverterParameter = cancelEventArgsConverterParameter,
                CancelEventArgsPropertyPath = cancelEventArgsPropertyPath,
                Destruction = "Destruction",
                DestructionCommand = destructionCommand,
                DestructionCommandParameter = destructionCommandParameter,
                DestructionEventArgsConverter = destructionEventArgsConverter,
                DestructionEventArgsConverterParameter = destructionEventArgsConverterParameter,
                DestructionEventArgsPropertyPath = destructionEventArgsPropertyPath,
            };

            var actionSheetButtonMockA = new Mock<IActionSheetButton>();
            actionSheetButtonMockA.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockA");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockA.Object);

            var actionSheetButtonMockB = new Mock<IActionSheetButton>();
            actionSheetButtonMockB.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockB");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockB.Object);

            var page = new PageMock();
            page.Behaviors.Add(behavior);
            MessagingCenter.Subscribe<Page, ActionSheetArguments>(this, Page.ActionSheetSignalName, (page1, arguments) =>
            {
                if (arguments.Title == "WhenSelectedActionSheetButtonOnEventRaised")
                {
                    Assert.Equal("Cancel", arguments.Cancel);
                    Assert.Equal("Destruction", arguments.Destruction);
                    Assert.Equal(2, arguments.Buttons.Count());
                    Assert.Equal("actionSheetButtonMockA", arguments.Buttons.ToArray()[0]);
                    Assert.Equal("actionSheetButtonMockB", arguments.Buttons.ToArray()[1]);
                    arguments.SetResult("actionSheetButtonMockB");
                }
            });

            page.RiseTestEvent(this, EventArgs.Empty);

            commandExecutorMock.Verify(
                commandExecutor => commandExecutor.Execute(It.IsAny<ICommand>(), It.IsAny<object>(), It.IsAny<EventArgs>(), It.IsAny<IValueConverter>(), It.IsAny<object>(), It.IsAny<string>()),
                Times.Never);
            actionSheetButtonMockA.Verify(x => x.OnClicked(It.IsAny<object>(), It.IsAny<EventArgs>()), Times.Never);
            actionSheetButtonMockB.Verify(x => x.OnClicked(this, EventArgs.Empty), Times.Once);
        }

        [Fact]
        public void WhenSelectedCancelOnDisplayActionSheetRequested()
        {
            var commandExecutorMock = new Mock<ICommandExecutor>();

            var cancelCommand = new Mock<ICommand>().Object;
            var cancelCommandParameter = new object();
            var cancelEventArgsConverter = new Mock<IValueConverter>().Object;
            var cancelEventArgsConverterParameter = new object();
            var cancelEventArgsPropertyPath = "cancelEventArgsPropertyPath";

            var destructionCommand = new Mock<ICommand>().Object;
            var destructionCommandParameter = new object();
            var destructionEventArgsConverter = new Mock<IValueConverter>().Object;
            var destructionEventArgsConverterParameter = new object();
            var destructionEventArgsPropertyPath = "destructionEventArgsPropertyPath";

            var request = new DisplayActionSheetRequest();
            var behavior = new DisplayActionSheetBehavior()
            {
                CommandExecutor = commandExecutorMock.Object,
                EventName = "TestEvent",
                NotificationRequest = request,
                Title = "WhenSelectedCancelOnDisplayActionSheetRequested",
                Cancel = "Cancel",
                CancelCommand = cancelCommand,
                CancelCommandParameter = cancelCommandParameter,
                CancelEventArgsConverter = cancelEventArgsConverter,
                CancelEventArgsConverterParameter = cancelEventArgsConverterParameter,
                CancelEventArgsPropertyPath = cancelEventArgsPropertyPath,
                Destruction = "Destruction",
                DestructionCommand = destructionCommand,
                DestructionCommandParameter = destructionCommandParameter,
                DestructionEventArgsConverter = destructionEventArgsConverter,
                DestructionEventArgsConverterParameter = destructionEventArgsConverterParameter,
                DestructionEventArgsPropertyPath = destructionEventArgsPropertyPath,
            };

            var actionSheetButtonMockA = new Mock<IActionSheetButton>();
            actionSheetButtonMockA.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockA");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockA.Object);

            var actionSheetButtonMockB = new Mock<IActionSheetButton>();
            actionSheetButtonMockB.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockB");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockB.Object);

            var page = new PageMock();
            page.Behaviors.Add(behavior);
            MessagingCenter.Subscribe<Page, ActionSheetArguments>(this, Page.ActionSheetSignalName, (page1, arguments) =>
            {
                if (arguments.Title == "ReplacedWhenSelectedCancelOnDisplayActionSheetRequested")
                {
                    Assert.Equal("ReplacedCancel", arguments.Cancel);
                    Assert.Equal("ReplacedDestruction", arguments.Destruction);
                    Assert.Equal(2, arguments.Buttons.Count());
                    Assert.Equal("actionSheetButtonActionA", arguments.Buttons.ToArray()[0]);
                    Assert.Equal("actionSheetButtonActionB", arguments.Buttons.ToArray()[1]);
                    arguments.SetResult(arguments.Destruction);
                }
            });

            bool calledActionSheetButtonActionCancel = false;
            bool calledActionSheetButtonActionDestruction = false;
            bool calledActionSheetButtonActionA = false;
            bool calledActionSheetButtonActionB = false;
            var actionSheetButtonActionCancel = new ActionSheetButton { Message = "ReplacedCancel", Action = () => { calledActionSheetButtonActionCancel = true; } };
            var actionSheetButtonActionDestruction = new ActionSheetButton { Message = "ReplacedDestruction", Action = () => { calledActionSheetButtonActionDestruction = true; } };
            var actionSheetButtonActionA = new ActionSheetButton { Message = "actionSheetButtonActionA", Action = () => { calledActionSheetButtonActionA = true; } };
            var actionSheetButtonActionB = new ActionSheetButton { Message = "actionSheetButtonActionB", Action = () => { calledActionSheetButtonActionB = true; } };

            request.Raise("ReplacedWhenSelectedCancelOnDisplayActionSheetRequested", actionSheetButtonActionCancel, actionSheetButtonActionDestruction, actionSheetButtonActionA, actionSheetButtonActionB);


            commandExecutorMock.Verify(
                commandExecutor => commandExecutor.Execute(It.IsAny<ICommand>(), It.IsAny<object>(), It.IsAny<EventArgs>(), It.IsAny<IValueConverter>(), It.IsAny<object>(), It.IsAny<string>()),
                Times.Never);
            actionSheetButtonMockA.Verify(x => x.OnClicked(It.IsAny<object>(), It.IsAny<EventArgs>()), Times.Never);
            actionSheetButtonMockB.Verify(x => x.OnClicked(It.IsAny<object>(), It.IsAny<EventArgs>()), Times.Never);
            Assert.False(calledActionSheetButtonActionCancel);
            Assert.True(calledActionSheetButtonActionDestruction);
            Assert.False(calledActionSheetButtonActionA);
            Assert.False(calledActionSheetButtonActionB);
        }

        [Fact]
        public void WhenSelectedDestructionOnDisplayActionSheetRequested()
        {
            var commandExecutorMock = new Mock<ICommandExecutor>();

            var cancelCommand = new Mock<ICommand>().Object;
            var cancelCommandParameter = new object();
            var cancelEventArgsConverter = new Mock<IValueConverter>().Object;
            var cancelEventArgsConverterParameter = new object();
            var cancelEventArgsPropertyPath = "cancelEventArgsPropertyPath";

            var destructionCommand = new Mock<ICommand>().Object;
            var destructionCommandParameter = new object();
            var destructionEventArgsConverter = new Mock<IValueConverter>().Object;
            var destructionEventArgsConverterParameter = new object();
            var destructionEventArgsPropertyPath = "destructionEventArgsPropertyPath";

            var request = new DisplayActionSheetRequest();
            var behavior = new DisplayActionSheetBehavior()
            {
                CommandExecutor = commandExecutorMock.Object,
                EventName = "TestEvent",
                NotificationRequest = request,
                Title = "WhenSelectedDestructionOnDisplayActionSheetRequested",
                Cancel = "Cancel",
                CancelCommand = cancelCommand,
                CancelCommandParameter = cancelCommandParameter,
                CancelEventArgsConverter = cancelEventArgsConverter,
                CancelEventArgsConverterParameter = cancelEventArgsConverterParameter,
                CancelEventArgsPropertyPath = cancelEventArgsPropertyPath,
                Destruction = "Destruction",
                DestructionCommand = destructionCommand,
                DestructionCommandParameter = destructionCommandParameter,
                DestructionEventArgsConverter = destructionEventArgsConverter,
                DestructionEventArgsConverterParameter = destructionEventArgsConverterParameter,
                DestructionEventArgsPropertyPath = destructionEventArgsPropertyPath,
            };

            var actionSheetButtonMockA = new Mock<IActionSheetButton>();
            actionSheetButtonMockA.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockA");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockA.Object);

            var actionSheetButtonMockB = new Mock<IActionSheetButton>();
            actionSheetButtonMockB.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockB");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockB.Object);

            var page = new PageMock();
            page.Behaviors.Add(behavior);
            MessagingCenter.Subscribe<Page, ActionSheetArguments>(this, Page.ActionSheetSignalName, (page1, arguments) =>
            {
                if (arguments.Title == "ReplacedWhenSelectedDestructionOnDisplayActionSheetRequested")
                {
                    Assert.Equal("ReplacedCancel", arguments.Cancel);
                    Assert.Equal("ReplacedDestruction", arguments.Destruction);
                    Assert.Equal(2, arguments.Buttons.Count());
                    Assert.Equal("actionSheetButtonActionA", arguments.Buttons.ToArray()[0]);
                    Assert.Equal("actionSheetButtonActionB", arguments.Buttons.ToArray()[1]);
                    arguments.SetResult(arguments.Destruction);
                }
            });

            bool calledActionSheetButtonActionCancel = false;
            bool calledActionSheetButtonActionDestruction = false;
            bool calledActionSheetButtonActionA = false;
            bool calledActionSheetButtonActionB = false;
            var actionSheetButtonActionCancel = new ActionSheetButton { Message = "ReplacedCancel", Action = () => { calledActionSheetButtonActionCancel = true; } };
            var actionSheetButtonActionDestruction = new ActionSheetButton { Message = "ReplacedDestruction", Action = () => { calledActionSheetButtonActionDestruction = true; } };
            var actionSheetButtonActionA = new ActionSheetButton { Message = "actionSheetButtonActionA", Action = () => { calledActionSheetButtonActionA = true; } };
            var actionSheetButtonActionB = new ActionSheetButton { Message = "actionSheetButtonActionB", Action = () => { calledActionSheetButtonActionB = true; } };

            request.Raise("ReplacedWhenSelectedDestructionOnDisplayActionSheetRequested", actionSheetButtonActionCancel, actionSheetButtonActionDestruction, actionSheetButtonActionA, actionSheetButtonActionB);


            commandExecutorMock.Verify(
                commandExecutor => commandExecutor.Execute(It.IsAny<ICommand>(), It.IsAny<object>(), It.IsAny<EventArgs>(), It.IsAny<IValueConverter>(), It.IsAny<object>(), It.IsAny<string>()),
                Times.Never);
            actionSheetButtonMockA.Verify(x => x.OnClicked(It.IsAny<object>(), It.IsAny<EventArgs>()), Times.Never);
            actionSheetButtonMockB.Verify(x => x.OnClicked(It.IsAny<object>(), It.IsAny<EventArgs>()), Times.Never);
            Assert.False(calledActionSheetButtonActionCancel);
            Assert.True(calledActionSheetButtonActionDestruction);
            Assert.False(calledActionSheetButtonActionA);
            Assert.False(calledActionSheetButtonActionB);
        }

        [Fact]
        public void WhenSelectedActionSheetButtonOnDisplayActionSheetRequested()
        {
            var commandExecutorMock = new Mock<ICommandExecutor>();

            var cancelCommand = new Mock<ICommand>().Object;
            var cancelCommandParameter = new object();
            var cancelEventArgsConverter = new Mock<IValueConverter>().Object;
            var cancelEventArgsConverterParameter = new object();
            var cancelEventArgsPropertyPath = "cancelEventArgsPropertyPath";

            var destructionCommand = new Mock<ICommand>().Object;
            var destructionCommandParameter = new object();
            var destructionEventArgsConverter = new Mock<IValueConverter>().Object;
            var destructionEventArgsConverterParameter = new object();
            var destructionEventArgsPropertyPath = "destructionEventArgsPropertyPath";

            var request = new DisplayActionSheetRequest();
            var behavior = new DisplayActionSheetBehavior()
            {
                CommandExecutor = commandExecutorMock.Object,
                NotificationRequest = request,
                Title = "WhenSelectedActionSheetButtonOnDisplayActionSheetRequested",
                Cancel = "Cancel",
                CancelCommand = cancelCommand,
                CancelCommandParameter = cancelCommandParameter,
                CancelEventArgsConverter = cancelEventArgsConverter,
                CancelEventArgsConverterParameter = cancelEventArgsConverterParameter,
                CancelEventArgsPropertyPath = cancelEventArgsPropertyPath,
                Destruction = "Destruction",
                DestructionCommand = destructionCommand,
                DestructionCommandParameter = destructionCommandParameter,
                DestructionEventArgsConverter = destructionEventArgsConverter,
                DestructionEventArgsConverterParameter = destructionEventArgsConverterParameter,
                DestructionEventArgsPropertyPath = destructionEventArgsPropertyPath,
            };

            var actionSheetButtonMockA = new Mock<IActionSheetButton>();
            actionSheetButtonMockA.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockA");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockA.Object);

            var actionSheetButtonMockB = new Mock<IActionSheetButton>();
            actionSheetButtonMockB.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockB");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockB.Object);

            var page = new PageMock();
            page.Behaviors.Add(behavior);
            MessagingCenter.Subscribe<Page, ActionSheetArguments>(this, Page.ActionSheetSignalName, (page1, arguments) =>
            {
                if (arguments.Title == "ReplacedWhenSelectedActionSheetButtonOnDisplayActionSheetRequested")
                {
                    Assert.Equal("ReplacedCancel", arguments.Cancel);
                    Assert.Equal("ReplacedDestruction", arguments.Destruction);
                    Assert.Equal(2, arguments.Buttons.Count());
                    Assert.Equal("actionSheetButtonActionA", arguments.Buttons.ToArray()[0]);
                    Assert.Equal("actionSheetButtonActionB", arguments.Buttons.ToArray()[1]);
                    arguments.SetResult("actionSheetButtonActionB");
                }
            });

            bool calledActionSheetButtonActionCancel = false;
            bool calledActionSheetButtonActionDestruction = false;
            bool calledActionSheetButtonActionA = false;
            bool calledActionSheetButtonActionB = false;
            string param = null;
            var actionSheetButtonActionCancel = new ActionSheetButton { Message = "ReplacedCancel", Action = () => { calledActionSheetButtonActionCancel = true; } };
            var actionSheetButtonActionDestruction = new ActionSheetButton { Message = "ReplacedDestruction", Action = () => { calledActionSheetButtonActionDestruction = true; } };
            var actionSheetButtonActionA = new ActionSheetButton { Message = "actionSheetButtonActionA", Action = () => { calledActionSheetButtonActionA = true; } };
            var actionSheetButtonActionB = new ActionSheetButton<string>
            {
                Message = "actionSheetButtonActionB",
                Parameter = "Param",
                Action =
                    x =>
                    {
                        calledActionSheetButtonActionB = true;
                        param = x;
                    }
            };

            request.Raise("ReplacedWhenSelectedActionSheetButtonOnDisplayActionSheetRequested", actionSheetButtonActionCancel, actionSheetButtonActionDestruction, actionSheetButtonActionA, actionSheetButtonActionB);

            commandExecutorMock.Verify(
                commandExecutor => commandExecutor.Execute(It.IsAny<ICommand>(), It.IsAny<object>(), It.IsAny<EventArgs>(), It.IsAny<IValueConverter>(), It.IsAny<object>(), It.IsAny<string>()),
                Times.Never);
            actionSheetButtonMockA.Verify(x => x.OnClicked(It.IsAny<object>(), It.IsAny<EventArgs>()), Times.Never);
            actionSheetButtonMockB.Verify(x => x.OnClicked(It.IsAny<object>(), It.IsAny<EventArgs>()), Times.Never);
            Assert.False(calledActionSheetButtonActionCancel);
            Assert.False(calledActionSheetButtonActionDestruction);
            Assert.False(calledActionSheetButtonActionA);
            Assert.True(calledActionSheetButtonActionB);
            Assert.Equal("Param", param);
        }

        [Fact]
        public void WhenNotSelectedButtons()
        {
            var commandExecutorMock = new Mock<ICommandExecutor>();

            var cancelCommand = new Mock<ICommand>().Object;
            var cancelCommandParameter = new object();
            var cancelEventArgsConverter = new Mock<IValueConverter>().Object;
            var cancelEventArgsConverterParameter = new object();
            var cancelEventArgsPropertyPath = "cancelEventArgsPropertyPath";

            var destructionCommand = new Mock<ICommand>().Object;
            var destructionCommandParameter = new object();
            var destructionEventArgsConverter = new Mock<IValueConverter>().Object;
            var destructionEventArgsConverterParameter = new object();
            var destructionEventArgsPropertyPath = "destructionEventArgsPropertyPath";

            var behavior = new DisplayActionSheetBehavior()
            {
                CommandExecutor = commandExecutorMock.Object,
                EventName = "TestEvent",
                Title = "WhenNotSelectedButtons",
                Cancel = "Cancel",
                CancelCommand = cancelCommand,
                CancelCommandParameter = cancelCommandParameter,
                CancelEventArgsConverter = cancelEventArgsConverter,
                CancelEventArgsConverterParameter = cancelEventArgsConverterParameter,
                CancelEventArgsPropertyPath = cancelEventArgsPropertyPath,
                Destruction = "Destruction",
                DestructionCommand = destructionCommand,
                DestructionCommandParameter = destructionCommandParameter,
                DestructionEventArgsConverter = destructionEventArgsConverter,
                DestructionEventArgsConverterParameter = destructionEventArgsConverterParameter,
                DestructionEventArgsPropertyPath = destructionEventArgsPropertyPath,
            };

            var actionSheetButtonMockA = new Mock<IActionSheetButton>();
            actionSheetButtonMockA.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockA");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockA.Object);

            var actionSheetButtonMockB = new Mock<IActionSheetButton>();
            actionSheetButtonMockB.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockB");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockB.Object);

            var page = new PageMock();
            page.Behaviors.Add(behavior);
            MessagingCenter.Subscribe<Page, ActionSheetArguments>(this, Page.ActionSheetSignalName, (page1, arguments) =>
            {
                if (arguments.Title == "WhenNotSelectedButtons")
                {
                    Assert.Equal("Cancel", arguments.Cancel);
                    Assert.Equal("Destruction", arguments.Destruction);
                    Assert.Equal(2, arguments.Buttons.Count());
                    Assert.Equal("actionSheetButtonMockA", arguments.Buttons.ToArray()[0]);
                    Assert.Equal("actionSheetButtonMockB", arguments.Buttons.ToArray()[1]);
                    arguments.SetResult(null);
                }
            });

            page.RiseTestEvent(this, EventArgs.Empty);

            commandExecutorMock.Verify(
                commandExecutor => commandExecutor.Execute(
                    It.IsAny<ICommand>(),
                    It.IsAny<object>(),
                    It.IsAny<EventArgs>(),
                    It.IsAny<IValueConverter>(),
                    It.IsAny<object>(),
                    It.IsAny<string>()),
                Times.Never);
        }

        [Fact]
        public void WhenCancelAndDestructionIsNull()
        {
            var commandExecutorMock = new Mock<ICommandExecutor>();

            var cancelCommand = new Mock<ICommand>().Object;
            var cancelCommandParameter = new object();
            var cancelEventArgsConverter = new Mock<IValueConverter>().Object;
            var cancelEventArgsConverterParameter = new object();
            var cancelEventArgsPropertyPath = "cancelEventArgsPropertyPath";

            var destructionCommand = new Mock<ICommand>().Object;
            var destructionCommandParameter = new object();
            var destructionEventArgsConverter = new Mock<IValueConverter>().Object;
            var destructionEventArgsConverterParameter = new object();
            var destructionEventArgsPropertyPath = "destructionEventArgsPropertyPath";

            var behavior = new DisplayActionSheetBehavior()
            {
                CommandExecutor = commandExecutorMock.Object,
                EventName = "TestEvent",
                Title = "WhenCancelAndDestructionIsNull",
                CancelCommand = cancelCommand,
                CancelCommandParameter = cancelCommandParameter,
                CancelEventArgsConverter = cancelEventArgsConverter,
                CancelEventArgsConverterParameter = cancelEventArgsConverterParameter,
                CancelEventArgsPropertyPath = cancelEventArgsPropertyPath,
                DestructionCommand = destructionCommand,
                DestructionCommandParameter = destructionCommandParameter,
                DestructionEventArgsConverter = destructionEventArgsConverter,
                DestructionEventArgsConverterParameter = destructionEventArgsConverterParameter,
                DestructionEventArgsPropertyPath = destructionEventArgsPropertyPath,
            };

            var actionSheetButtonMockA = new Mock<IActionSheetButton>();
            actionSheetButtonMockA.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockA");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockA.Object);

            var actionSheetButtonMockB = new Mock<IActionSheetButton>();
            actionSheetButtonMockB.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockB");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockB.Object);

            var page = new PageMock();
            page.Behaviors.Add(behavior);
            MessagingCenter.Subscribe<Page, ActionSheetArguments>(this, Page.ActionSheetSignalName, (page1, arguments) =>
            {
                if (arguments.Title == "WhenCancelAndDestructionIsNull")
                {
                    Assert.Null(arguments.Cancel);
                    Assert.Null(arguments.Destruction);
                    Assert.Equal(2, arguments.Buttons.Count());
                    Assert.Equal("actionSheetButtonMockA", arguments.Buttons.ToArray()[0]);
                    Assert.Equal("actionSheetButtonMockB", arguments.Buttons.ToArray()[1]);
                    arguments.SetResult("actionSheetButtonMockB");
                }
            });

            page.RiseTestEvent(this, EventArgs.Empty);

            commandExecutorMock.Verify(
                commandExecutor => commandExecutor.Execute(
                    It.IsAny<ICommand>(),
                    It.IsAny<object>(),
                    It.IsAny<EventArgs>(),
                    It.IsAny<IValueConverter>(),
                    It.IsAny<object>(),
                    It.IsAny<string>()),
                Times.Never);
            actionSheetButtonMockA.Verify(m => m.OnClicked(It.IsAny<object>(), It.IsAny<EventArgs>()), Times.Never);
            actionSheetButtonMockB.Verify(m => m.OnClicked(It.IsAny<object>(), It.IsAny<EventArgs>()), Times.Once);
        }

        [Fact]
        public void WhenNotSelectedButtonsOnDisplayActionSheetRequested()
        {
            var commandExecutorMock = new Mock<ICommandExecutor>();

            var request = new DisplayActionSheetRequest();
            var behavior = new DisplayActionSheetBehavior()
            {
                CommandExecutor = commandExecutorMock.Object,
                NotificationRequest = request,
            };

            var actionSheetButtonMockA = new Mock<IActionSheetButton>();
            actionSheetButtonMockA.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockA");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockA.Object);

            var actionSheetButtonMockB = new Mock<IActionSheetButton>();
            actionSheetButtonMockB.SetupGet(x => x.Message).Returns(() => "actionSheetButtonMockB");
            behavior.ActionSheetButtons.Add(actionSheetButtonMockB.Object);

            var page = new PageMock();
            page.Behaviors.Add(behavior);
            MessagingCenter.Subscribe<Page, ActionSheetArguments>(this, Page.ActionSheetSignalName, (page1, arguments) =>
            {
                if (arguments.Title == "WhenNotSelectedButtonsOnDisplayActionSheetRequested")
                {
                    Assert.Equal("ReplacedCancel", arguments.Cancel);
                    Assert.Equal("ReplacedDestruction", arguments.Destruction);
                    Assert.Equal(2, arguments.Buttons.Count());
                    Assert.Equal("actionSheetButtonActionA", arguments.Buttons.ToArray()[0]);
                    Assert.Equal("actionSheetButtonActionB", arguments.Buttons.ToArray()[1]);
                    arguments.SetResult(null);
                }
            });

            bool calledActionSheetButtonActionCancel = false;
            bool calledActionSheetButtonActionDestruction = false;
            bool calledActionSheetButtonActionA = false;
            bool calledActionSheetButtonActionB = false;
            var actionSheetButtonActionCancel = new ActionSheetButton { Message = "ReplacedCancel", Action = () => { calledActionSheetButtonActionCancel = true; } };
            var actionSheetButtonActionDestruction = new ActionSheetButton { Message = "ReplacedDestruction", Action = () => { calledActionSheetButtonActionDestruction = true; } };
            var actionSheetButtonActionA = new ActionSheetButton { Message = "actionSheetButtonActionA", Action = () => { calledActionSheetButtonActionA = true; } };
            var actionSheetButtonActionB = new ActionSheetButton { Message = "actionSheetButtonActionB", Action = () => { calledActionSheetButtonActionB = true; } };

            request.Raise("WhenNotSelectedButtonsOnDisplayActionSheetRequested", actionSheetButtonActionCancel, actionSheetButtonActionDestruction, actionSheetButtonActionA, actionSheetButtonActionB);

            page.RiseTestEvent(this, EventArgs.Empty);

            commandExecutorMock.Verify(
                commandExecutor => commandExecutor.Execute(
                    It.IsAny<ICommand>(),
                    It.IsAny<object>(),
                    It.IsAny<EventArgs>(),
                    It.IsAny<IValueConverter>(),
                    It.IsAny<object>(),
                    It.IsAny<string>()),
                Times.Never);

            Assert.False(calledActionSheetButtonActionCancel);
            Assert.False(calledActionSheetButtonActionDestruction);
            Assert.False(calledActionSheetButtonActionA);
            Assert.False(calledActionSheetButtonActionB);
        }

        [Fact]
        public void WhenCancelAndDestructionIsNullOnDisplayActionSheetRequested()
        {
            var commandExecutorMock = new Mock<ICommandExecutor>();

            var request = new DisplayActionSheetRequest();
            var behavior = new DisplayActionSheetBehavior()
            {
                CommandExecutor = commandExecutorMock.Object,
                NotificationRequest = request,
                EventName = "TestEvent",
                Title = "WhenCancelAndDestructionIsNullOnDisplayActionSheetRequested",
            };

            var page = new PageMock();
            page.Behaviors.Add(behavior);
            MessagingCenter.Subscribe<Page, ActionSheetArguments>(this, Page.ActionSheetSignalName, (page1, arguments) =>
            {
                if (arguments.Title == "WhenCancelAndDestructionIsNullOnDisplayActionSheetRequested")
                {
                    Assert.Null(arguments.Cancel);
                    Assert.Null(arguments.Destruction);
                    Assert.Equal(2, arguments.Buttons.Count());
                    Assert.Equal("actionSheetButtonActionA", arguments.Buttons.ToArray()[0]);
                    Assert.Equal("actionSheetButtonActionB", arguments.Buttons.ToArray()[1]);
                    arguments.SetResult("actionSheetButtonActionB");
                }
            });

            bool calledActionSheetButtonActionA = false;
            bool calledActionSheetButtonActionB = false;
            string param = null;
            var actionSheetButtonActionA = new ActionSheetButton { Message = "actionSheetButtonActionA", Action = () => { calledActionSheetButtonActionA = true; } };
            var actionSheetButtonActionB = new ActionSheetButton<string>
            {
                Message = "actionSheetButtonActionB",
                Parameter = "Param",
                Action =
                    x =>
                    {
                        calledActionSheetButtonActionB = true;
                        param = x;
                    }
            };

            request.Raise("WhenCancelAndDestructionIsNullOnDisplayActionSheetRequested", null, null, actionSheetButtonActionA, actionSheetButtonActionB);

            commandExecutorMock.Verify(
                commandExecutor => commandExecutor.Execute(
                    It.IsAny<ICommand>(),
                    It.IsAny<object>(),
                    It.IsAny<EventArgs>(),
                    It.IsAny<IValueConverter>(),
                    It.IsAny<object>(),
                    It.IsAny<string>()),
                Times.Never);
            Assert.False(calledActionSheetButtonActionA);
            Assert.True(calledActionSheetButtonActionB);
            Assert.Equal("Param", param);
        }

        [Fact]
        public void OnBindingContextChanged()
        {
            var behavior = new DisplayActionSheetBehavior();
            var actionSeetButtonA = new ActionSheetButton();
            behavior.ActionSheetButtons.Add(actionSeetButtonA);
            var actionSeetButtonB = new ActionSheetButton();
            behavior.ActionSheetButtons.Add(actionSeetButtonB);

            var bindingObject = new object();
            behavior.BindingContext = bindingObject;

            Assert.Equal(bindingObject, actionSeetButtonA.BindingContext);
            Assert.Equal(bindingObject, actionSeetButtonB.BindingContext);
        }

        [Fact]
        public void OnCollectionChanged()
        {
            var behavior = new DisplayActionSheetBehavior();
            var bindingObject = new object();
            behavior.BindingContext = bindingObject;

            var actionSeetButtonA = new ActionSheetButton();
            behavior.ActionSheetButtons.Add(actionSeetButtonA);
            var actionSeetButtonB = new ActionSheetButton();
            behavior.ActionSheetButtons.Add(actionSeetButtonB);

            behavior.ActionSheetButtons.Remove(actionSeetButtonA);

            Assert.Equal(bindingObject, actionSeetButtonA.BindingContext);
            Assert.Equal(bindingObject, actionSeetButtonB.BindingContext);
        }

        private class PageMock : ContentPage
        {
            // ReSharper disable once EventNeverSubscribedTo.Local
            public event EventHandler<EventArgs> TestEvent;

            public PageMock()
            {
                IsPlatformEnabled = true;
            }

            public void RiseTestEvent(object sender, EventArgs eventArgs)
            {
                TestEvent?.Invoke(sender, eventArgs);
            }
        }

    }
}
