<template>
  <div class="auth-container">
    <div class="auth-container__welcome-msg">Register</div>
    <div class="auth-container__welcome-msg--tiny">Some text needed here!</div>
    <el-form class="auth-container__form--register" :rules="rules" :model="user">
      <el-form-item prop="email">
        <el-input type="text" v-model="user.email" placeholder="Email"/>
      </el-form-item>
      <el-form-item prop="group">
        <el-select v-model="user.academicGroup" placeholder="Select group">
          <el-option
              v-for="group in academicGroups"
              :key="group.id"
              :label="group.name"
              :value="group.id"
          />
        </el-select>
      </el-form-item>
      <el-form-item prop="password">
        <el-input type="password" v-model="user.password" placeholder="Password"/>
      </el-form-item>
      <el-form-item prop="passwordConfirm">
        <el-input type="password" v-model="user.confirmPassword" placeholder="Confirm password"/>
      </el-form-item>
    </el-form>
    <el-button class="button--submit-auth-form"><i class="el-icon-right"/></el-button>
    <div class="auth-container__redirect">
      <router-link class="link" :to="{name: 'Login'}">LogIn</router-link>
      <router-link class="link" :to="{name: 'ForgotPassword'}">Forgot password?</router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "RegisterComponent",
  data() {
    const confirmPasswordValidator = (rule, value, callback) => {
      if (!this.user.confirmPassword) {
        callback(new Error("Please confirm password"));
      } else if (this.user.confirmPassword !== this.user.password) {
        callback(new Error("Confirm password does not match"));
      } else {
        callback();
      }
    }
    return {
      user: {
        email: "",
        academicGroup: "",
        password: "",
        confirmPassword: "",
      },
      rules: {
        email: [
          {
            required: true,
            message: "Email is required",
            trigger: ["change", "blur"],
          },
          {
            type: 'email',
            message: "Invalid email type",
            trigger: ["change", "blur"],
          }
        ],
        group: [
          {
            required: true,
            message: "Academic group is required",
            trigger: ["blur"],
          }
        ],
        password: [
          {
            required: true,
            message: "Password is required",
            trigger: ["change", "blur"],
          },
          {
            min: 8,
            message: "Password is too short",
            trigger: ["blur"],
          }
        ],
        passwordConfirm: [
          {
            validator: confirmPasswordValidator,
            trigger: ["change", "blur"],
          }
        ],
      }
    };
  },
  computed: {
    academicGroups() {
      return [
        {
          id: 1,
          name: "FAF-201"
        },
        {
          id: 2,
          name: "FAF-202"
        },
        {
          id: 3,
          name: "FAF-203"
        },
      ]
    },
  },
}
</script>

<style scoped lang="scss">
.button--submit-auth-form {
  position: absolute;
  top: calc(15vh + 435px);
  left: calc(50% - 40px);
}

@media only screen and (max-width: 768px) {
  .button--submit-auth-form {
    top: calc(30vh + 370px);
  }
}
</style>