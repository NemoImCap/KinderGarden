﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан инструментальным средством
//     В случае повторного создания кода изменения, внесенные в этот файл, будут потеряны.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IChildService 
{
	void AddChild(Child child);

	void UpdteChild(Child child);

	void DeleteChild(Child child);

	IEnumerable<Child> GetChildren(int? gartenId, int? gartenNumber, int? age, string search = "", int page = 1);

	Child GetChildById(int id);
    void RemoveKinderGarten(IEnumerable<Child> children);

}

