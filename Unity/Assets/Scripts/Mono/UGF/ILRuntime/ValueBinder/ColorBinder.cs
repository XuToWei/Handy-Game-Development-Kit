using UnityEngine;
using System.Collections.Generic;
using ILRuntime.Other;
using System;
using System.Reflection;
using ILRuntime.Runtime.Enviorment;
using ILRuntime.Runtime.Intepreter;
using ILRuntime.CLR.Method;
using ILRuntime.CLR.TypeSystem;
using ILRuntime.Runtime.Stack;

namespace UGF
{
    public unsafe class ColorBinder : ValueTypeBinder<Color>
    {
        public override unsafe void AssignFromStack(ref Color ins, StackObject* ptr, IList<object> mStack)
        {
            var v = ILIntepreter.Minus(ptr, 1);
            ins.a = *(float*)&v->Value;
            v = ILIntepreter.Minus(ptr, 2);
            ins.r = *(float*)&v->Value;
            v = ILIntepreter.Minus(ptr, 3);
            ins.g = *(float*)&v->Value;
            v = ILIntepreter.Minus(ptr, 4);
            ins.b = *(float*)&v->Value;
        }

        public override unsafe void CopyValueTypeToStack(ref Color ins, StackObject* ptr, IList<object> mStack)
        {
            var v = ILIntepreter.Minus(ptr, 1);
            *(float*)&v->Value = ins.a;
            v = ILIntepreter.Minus(ptr, 2);
            *(float*)&v->Value = ins.r;
            v = ILIntepreter.Minus(ptr, 3);
            *(float*)&v->Value = ins.g;
            v = ILIntepreter.Minus(ptr, 4);
            *(float*)&v->Value = ins.b;
        }
        public override void RegisterCLRRedirection(ILRuntime.Runtime.Enviorment.AppDomain appdomain)
        {
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly;
            MethodBase method;
            Type[] args;
            Type type = typeof(Color);
            args = new Type[] { typeof(float), typeof(float), typeof(float), typeof(float) };
            method = type.GetConstructor(flag, null, args, null);
            appdomain.RegisterCLRMethodRedirection(method, NewColor);
        }

        StackObject* NewColor(ILIntepreter intp, StackObject* esp, IList<object> mStack, CLRMethod method, bool isNewObj)
        {
            StackObject* ret;
            if (isNewObj)
            {
                ret = ILIntepreter.Minus(esp, 3);
                Color vec;
                var ptr = ILIntepreter.Minus(esp, 1);
                vec.a = *(float*)&ptr->Value;
                ptr = ILIntepreter.Minus(esp, 2);
                vec.b = *(float*)&ptr->Value;
                ptr = ILIntepreter.Minus(esp, 3);
                vec.g = *(float*)&ptr->Value;
                ptr = ILIntepreter.Minus(esp, 4);
                vec.r = *(float*)&ptr->Value;

                PushColor(ref vec, intp, ptr, mStack);
            }
            else
            {
                ret = ILIntepreter.Minus(esp, 5);
                var instance = ILIntepreter.GetObjectAndResolveReference(ret);
                var dst = *(StackObject**)&instance->Value;
                var f = ILIntepreter.Minus(dst, 2);
                var v = ILIntepreter.Minus(esp, 4);
                *f = *v;

                f = ILIntepreter.Minus(dst, 3);
                v = ILIntepreter.Minus(esp, 3);
                *f = *v;

                f = ILIntepreter.Minus(dst, 4);
                v = ILIntepreter.Minus(esp, 2);
                *f = *v;

                f = ILIntepreter.Minus(dst, 1);
                v = ILIntepreter.Minus(esp, 1);
                *f = *v;
            }
            return ret;
        }

        static void ParseColor(out Color vec, ILIntepreter intp, StackObject* ptr, IList<object> mStack)
        {
            var a = ILIntepreter.GetObjectAndResolveReference(ptr);
            if (a->ObjectType == ObjectTypes.ValueTypeObjectReference)
            {
                var src = *(StackObject**)&a->Value;
                vec.a = *(float*)&ILIntepreter.Minus(src, 1)->Value;
                vec.r = *(float*)&ILIntepreter.Minus(src, 2)->Value;
                vec.g = *(float*)&ILIntepreter.Minus(src, 3)->Value;
                vec.b = *(float*)&ILIntepreter.Minus(src, 4)->Value;
                intp.FreeStackValueType(ptr);
            }
            else
            {
                vec = (Color)StackObject.ToObject(a, intp.AppDomain, mStack);
                intp.Free(ptr);
            }
        }

        void PushColor(ref Color vec, ILIntepreter intp, StackObject* ptr, IList<object> mStack)
        {
            intp.AllocValueType(ptr, CLRType);
            var dst = *((StackObject**)&ptr->Value);
            CopyValueTypeToStack(ref vec, dst, mStack);
        }
    }
}


